/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [        
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'clipboard', groups: ['clipboard'] },
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'styles' },
        { name: 'colors' },
	    { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align'] },
        
		{ name: 'links' },
		{ name: 'insert' },

		{ name: 'tools' }
		
	];
    config.protectedSource.push(/<i[^>]*><\/i>/g);
	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
    config.removeButtons = 'Underline,Subscript,Superscript,undo,Anchor,block,Blockquote';
    config.height = '350px';

	// Set the most common block elements.
    config.format_tags = 'p;h1;h2;h3;pre;div';
    config.allowedContent = true;
    config.contentsCss = 'https://bankersheart.com/css/base.css';
    //config.contentsCss = 'http://www.dotcompreview.com/taashya/css/base.css';
    //config.contentsCss = 'http://localhost:60626/css/basestyle.css';
    
    

	// Simplify the dialog windows.    
    config.removeDialogTabs = 'image:advanced;link:advanced';
   
    
};

