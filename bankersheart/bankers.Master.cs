using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankersheart
{
    public partial class bankers : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.PreRender += SiteMaster_PreRender;
        }

        void SiteMaster_PreRender(object sender, EventArgs e)
        {
            // Wrap the response stream with our custom filter before rendering finishes
            Response.Filter = new ImageDimensionFilter(Response.Filter, Server.MapPath("~/"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public class ImageDimensionFilter : Stream
        {
            private Stream _responseStream;
            private MemoryStream _buffer = new MemoryStream();
            private string _rootPath;

            public ImageDimensionFilter(Stream responseStream, string rootPath)
            {
                _responseStream = responseStream;
                _rootPath = rootPath;
            }

            public override bool CanRead { get { return false; } }
            public override bool CanSeek { get { return false; } }
            public override bool CanWrite { get { return true; } }

            public override void Flush()
            {
                // Don't flush the buffer here; we flush after processing in Close()
            }

            public override long Length { get { throw new NotSupportedException(); } }
            public override long Position { get { throw new NotSupportedException(); } set { throw new NotSupportedException(); } }
            public override int Read(byte[] buffer, int offset, int count) { throw new NotSupportedException(); }
            public override long Seek(long offset, SeekOrigin origin) { throw new NotSupportedException(); }
            public override void SetLength(long value) { throw new NotSupportedException(); }

            // Buffer all data written to the stream
            public override void Write(byte[] buffer, int offset, int count)
            {
                _buffer.Write(buffer, offset, count);
            }

            // Called when response ends — process and write the modified HTML
            public override void Close()
            {
                try
                {
                    // Convert buffered bytes to string
                    string html = Encoding.UTF8.GetString(_buffer.ToArray());

                    // Pattern to find img tags
                    string pattern = @"<img\b[^>]*?>";

                    // Replace img tags using our evaluator method
                    string replacedHtml = Regex.Replace(html, pattern, new MatchEvaluator(ProcessImgTag), RegexOptions.IgnoreCase);

                    // Write processed HTML back to the output stream
                    byte[] outData = Encoding.UTF8.GetBytes(replacedHtml);
                    _responseStream.Write(outData, 0, outData.Length);
                    _responseStream.Flush();
                }
                catch (Exception ex)
                {
                    // On error, fallback: write original content unmodified
                    byte[] original = _buffer.ToArray();
                    _responseStream.Write(original, 0, original.Length);
                    _responseStream.Flush();
                }
                finally
                {
                    base.Close();
                }
            }

            private string ProcessImgTag(Match match)
            {
                string imgTag = match.Value;

                // Match src attribute
                Match srcMatch = Regex.Match(imgTag, @"src\s*=\s*[""']([^""']+)[""']", RegexOptions.IgnoreCase);
                if (!srcMatch.Success)
                    return imgTag;

                string src = srcMatch.Groups[1].Value;
                string imgPath = null;
                bool isExternal = src.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                                  src.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

                // Skip if already processed
                if (imgTag.Contains("data-processed=\"true\"") || imgTag.Contains("data-external=\"true\""))
                    return imgTag;

                // Try to resolve path
                if (!isExternal)
                {
                    string pageFolder = Path.GetDirectoryName(HttpContext.Current.Request.PhysicalPath);
                    string tryPath1 = Path.Combine(pageFolder, src.Replace('/', '\\'));

                    if (File.Exists(tryPath1))
                    {
                        imgPath = tryPath1;
                    }
                    else
                    {
                        string rootPath = HttpContext.Current.Server.MapPath("~/");
                        string tryPath2 = Path.Combine(rootPath, src.TrimStart('/').Replace('/', '\\'));

                        if (File.Exists(tryPath2))
                            imgPath = tryPath2;
                    }
                }
                else
                {
                    // Attempt to map external URL to local path
                    string srcLocal = src.Replace("https://www.bankersheart.com/", "/");
                    string rootPath = HttpContext.Current.Server.MapPath("~/");
                    string tryPath = Path.Combine(rootPath, srcLocal.TrimStart('/').Replace('/', '\\'));

                    if (File.Exists(tryPath))
                        imgPath = tryPath;
                }

                int? width = null;
                int? height = null;

                // Get intrinsic dimensions
                if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    try
                    {
                        using (var bmp = new System.Drawing.Bitmap(imgPath))
                        {
                            width = bmp.Width;
                            height = bmp.Height;
                        }
                    }
                    catch
                    {
                        // If error, do not modify tag
                        return imgTag;
                    }
                }
                else
                {
                    // Can't resolve path → don't touch the tag
                    return imgTag;
                }

                // Clean out existing width/height
                string cleanTag = Regex.Replace(imgTag, @"\s(width|height)\s*=\s*[""']?[^""'\s>]*[""']?", "", RegexOptions.IgnoreCase);

                // Build new attributes
                var attrs = new Dictionary<string, string>
    {
        { "width", width.ToString() },
        { "height", height.ToString() },
        { "loading", "lazy" }
    };

                if (isExternal)
                    attrs["data-external"] = "true";
                else
                    attrs["data-processed"] = "true";

                return AddOrReplaceAttributes(cleanTag, attrs);
            }


            private string AddOrReplaceAttributes(string tag, Dictionary<string, string> attributes)
            {
                int insertPos = tag.LastIndexOf("/>") >= 0
                    ? tag.LastIndexOf("/>")
                    : tag.LastIndexOf(">");

                if (insertPos == -1) return tag;

                string attrText = string.Join(" ", attributes.Select(kv =>
                    string.Format("{0}=\"{1}\"", kv.Key, kv.Value)));

                string newTag = tag.Substring(0, insertPos).TrimEnd() + " " + attrText + tag.Substring(insertPos);
                return newTag;
            }

        }

    }
}