/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

// Register a templates definition set named "default".
CKEDITOR.addTemplates( 'default', {
	// The name of sub folder which hold the shortcut preview images of the
	// templates.
	imagesPath: CKEDITOR.getUrl( CKEDITOR.plugins.getPath( 'templates' ) + 'templates/images/' ),

	// The templates definitions.
	templates: [
	
	
	  {
	     title: 'Chú thích ảnh',
	     image: 'template_chuthich.gif',
	     html: '<p class="p-chuthich" style="background: none repeat scroll 0 0 #f5f5f5;font-size:13px; color: #666;padding:3px 10px 3px 15px;position:relative;left:-10px;width:105%">Nội dung chú thích ảnh</p>'
	 },{
	     title: 'Ảnh và chú thích',
	     image: 'template_multi_center.gif',
	     html: ' <p><img alt="Nội dung ch&uacute; th&iacute;ch ảnh" style="opacity: 1;" src="../images/default_img.png" /><span class="sp-zoom"> </span></p>'
		 + '<p class="p-chuthich" style="background: none repeat scroll 0 0 #f5f5f5;font-size:13px; color: #666;padding:3px 10px 3px 15px;position:relative;left:-10px;width:105%">Nội dung chú thích ảnh</p>'
	 },{
	     title: 'Cuộc thi truyện ngắn',
	     image: 'template2.gif',
	     html: '<div class="box-tamsu" style="background-color: #f2f0e7;border: 1px solid #b1afae;border-radius: 20px;margin: 0 auto 15px;overflow: hidden;width: 300px;">'
            + '<div style=" clear: both;display: block;line-height: 21px;padding: 0 15px;text-align: justify;">'
            + '<p>Gửi tác phẩm (không quá 500 chữ) dự thi <a href="http://tiin.vn/chuyen-muc/song/the-le-cuoc-thi-truyen-ngan-smartphone-tren-tiinvn.html">'
            + '<strong>Truyện ngắn Smartphone</strong></a> để có cơ hội nhận được 5 triệu đồng và nhiều giải thưởng giá trị.</p>'
            + '<p>Gửi về địa chỉ: <strong>Duthi@tiin.vn</strong> kèm tiêu đề, họ tên, SĐT, Facebook liên lạc.</p></div>'
            + '</div>'
	 }, {
		title: 'Nhập thông tin :',
		image: 'template2.gif',
		description: 'Điền thông tin theo mẫu',
		html: '<div class="box-tamsu" style="background-color: #f2f0e7;border: 1px solid #b1afae;border-radius: 20px;margin: 0 auto 15px;overflow: hidden;width: 300px;">' 
			+'<div style="display: block;height: 15px;line-height: 0;overflow: hidden;width: 280px; font-size: 0;">'
            + '&nbsp;</div>'
            + '<div style=" clear: both;display: block;line-height: 21px;padding: 0 15px;text-align: justify;">'
            + 'Họ và tên người dự thi:</div>'
            + '<div style=" clear: both;display: block;line-height: 21px;padding: 0 15px;text-align: justify;">'
            + 'Bút danh:</div>'
            + '<div style=" clear: both;display: block;line-height: 21px;padding: 0 15px;text-align: justify;">'
            + 'Nghề nghiệp:</div>'
            + '<div style=" clear: both;display: block;line-height: 21px;padding: 0 15px;text-align: justify;">'
            + 'Email:</div>'
            + '<div style=" display: block;font-size: 0;height: 15px;line-height: 0;overflow: hidden;width: 270px;">'
            + '&nbsp;</div>'
            + '</div>'
},{
		title: 'multi-item-right:',
		image: 'template_multi_right.gif',
		description: 'Điền thông tin theo mẫu',
		html: '<div class="multi-item multi-item-right" style="overflow:hidden;"><p class="multi-item-img" style="width:50%;float:right;background:#f1f1f1;margin-left:20px;"> <img style="width:100%;" src="../images/layer-42-1485340922272.jpg"></p>'
            + '<div class="multi-content" style="background:#f1f1f1">'
            + '	<p>Nhập nội dung tại đây </p> '
			+ '   </div>       </div>'
			+ '<p>&nbsp;</p>'
            
	},
	{
		title: 'multi-item-Left:',
		image: 'template_multi_left.gif',
		description: 'Điền thông tin theo mẫu',
		html: '<div class="multi-item multi-item-left" style="overflow:hidden;"><p class="multi-item-img" style="width:50%;float:left;background:#f1f1f1;margin-right:20px;"> <img style="width:100%;" src="../images/layer-42-1485340922272.jpg"></p>'
            + '<div class="multi-content" style="background:#f1f1f1">'
            + '	<p>Nhập nội dung tại đây </p> '
			+ '   </div>       </div>'
			+ '<p>&nbsp;</p>'
			
            
	},
	{
		title: 'multi-item-Center:',
		image: 'template_multi_center.gif',
		description: 'Điền thông tin theo mẫu',
		html: '<div class="multi-item" style="overflow:hidden;"><p class="multi-item-img" style=";background:#f1f1f1;"> <img style="width:100%;" src="../images/layer-41-1485340826860.jpg"></p>'
            + '<div class="multi-content" style="background:#f1f1f1">'
            + '	<p>Nhập nội dung tại đây </p> '
			+ '   </div>       </div>'
			+ '<p>&nbsp;</p>'
            
		},{
		title: 'multi-item-icon:',
		image: 'template_multi_icon.gif',
		description: 'Điền thông tin theo mẫu',
		html: '<div class="multi-item" style="overflow:hidden;">'
            + '<div class="multi-content" style="background:#f1f1f1">'
			+ '<p class="multi-item-img" style="float:left;margin-right:15px;width:auto;"> <img style="width:100%;" src="../images/demo.jpg"></p>'  	
            + '	<p>Nhập nội dung tại đây </p> '
			+ '   </div>       </div>'
			+ '<p>&nbsp;</p>'
            
	},{
		title: 'template_infographic:',
		image: 'template_infographic.gif',
		description: 'Điền thông tin theo mẫu',
		html: '<div class="multi-item multi-item-graphic" style="overflow:hidden;"><p class="multi-item-img" style=";background:#f1f1f1;"> <img style="width:100%;" src="../images/layer-41-1485340826860.jpg"></p><p class="multi-item-img multi-wap" style=";background:#f1f1f1;"> <img style="width:100%;" src="../images/layer-41-1485340826860.jpg"></p>'
		    + '<div class="multi-content" style="background:#f1f1f1">'
            + '	<p>Nhập nội dung tại đây </p> '
			+ '   </div>       </div>'
	},
	{
		title: 'Gửi Thông Tin',
		image: 'template3.gif',
		description: 'Điền theo mẫu',
		html: 
            '<div class="box-tamsu" style="background-color: #f2f0e7;border: 1px solid #b1afae;border-radius: 20px;margin: 0 auto 15px;overflow: hidden;width: 280px;">'
            + '<div style="display: block;height: 22px;line-height: 0;overflow: hidden;width: 280px; font-size: 0;">'
            + '&nbsp;</div>'
            + '<div style=" clear: both;display: block;line-height: 21px;padding: 0 14px;text-align: justify;width: 260px;">'
            + 'Mọi sự giúp đỡ xin gửi về:</div>'
            + '<div style=" clear: both;display: block;line-height: 21px;padding: 0 14px;text-align: justify;width: 260px;">'
            + 'Chị <strong>Đinh Thị Dương </strong>(thôn 1, xã Đoàn Kết, huyện Đạ Huoai, tỉnh Lâm Đồng, ĐT: 0979 178 428)&nbsp;</div>'
            + '<div style=" display: block;font-size: 0;height: 21px;line-height: 0;overflow: hidden;width: 270px;">'
            + '&nbsp;</div>'
            + '</div>'

	},	
	{
		title: 'Ấn tượng tình yêu',
		image: 'template3.gif',
		description: 'Điền theo mẫu',
		html: 
		'<div style="background-color: #f2f0e7;border: 1px solid #b1afae;border-radius: 20px;margin: 0 auto 15px;overflow: hidden;width: 280px;" class="box-tamsu"><div style="display: block;height: 22px;line-height: 0;overflow: hidden;width: 280px; font-size: 0;">&nbsp;</div>'
		+ '<div style=" clear: both;display: block;line-height: 21px;padding: 0 14px;text-align: justify;width: 260px;">Kính mời quý độc giả gửi bài, ảnh hoặc clip tham gia cuộc thi <strong>Ấn tượng tình yêu</strong> '
		+ 'theo địa chỉ email <a href="mailto:Antuongtinhyeu@gmail.com">Antuongtinhyeu@gmail.com</a> để có cơ hội nhận giải tuần 500 nghìn đồng và giải chung cuộc 5 triệu đồng. Xem thể lệ chi tiết của cuộc thi '
		+ '<a href="http://tiin.vn/chuyen-muc/yeu/the-le-cuoc-thi-an-tuong-tinh-yeu-de-yeu-thuong-len-tieng.html"><strong>TẠI ĐÂY</strong></a>.</div>'
		+ '<div style=" display: block;font-size: 0;height: 21px;line-height: 0;overflow: hidden;width: 270px;">&nbsp;</div></div>'				           
	},
	{
		title: 'Nhập Tarot_01',
		image: 'template3.gif',
		description: 'Điền theo mẫu',
		html: 
		
		'<div class="tarot-card"><div class="tarot-card-row"><section class="singlecard">'
    + '<div  class="card">'
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">'
     + ' <img src="../images/tarot_01.png" />'
      + '</figure>'
      + '<div class="info-card">'
      	+ '<h3>  Tình yêu </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
    + '</div>'
	+'<h3 class="card-h3"></h3>'
 + ' </section>'
  + '<section class="singlecard">'
    + '<div  class="card">'
     + ' <figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">    '  	
      + '<img src="../images/tarot_02.png" />'
     + ' </figure>'
     + '  <div class="info-card">'
      + '	<h3>  Thiên đạo </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
 + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
  + ' <div class="info-tarot">'  	
 + ' </div>'
 + '</div>' 
+ '  </div>'

	},	
	{
		title: 'Nhập Tarot_02',
		image: 'template3.gif',
		description: 'Điền theo mẫu',
		html: 
		
		'<div class="tarot-card tarot-card-04"><div class="tarot-card-row"><section class="singlecard">'
    + '<div  class="card">'
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">'
     + ' <img src="../images/tarot_01.png" />'
      + '</figure>'
      + '<div class="info-card">'
      	+ '<h3>  Tình yêu </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
    + '</div>'
	+'<h3 class="card-h3"></h3>'
 + ' </section>'
  + '<section class="singlecard">'
    + '<div  class="card">'
     + ' <figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">    '  	
      + '<img src="../images/tarot_02.png" />'
     + ' </figure>'
     + '  <div class="info-card">'
      + '	<h3>  Thiên đạo </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
 + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
  + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
  + ' <div class="info-tarot">'  	
 + ' </div>'
 + '</div>' 
+ '  </div>'

	},	
	{
		title: 'Nhập Tarot_03',
		image: 'template3.gif',
		description: 'Điền theo mẫu',
		html: 
		
		'<div class="tarot-card"><div class="tarot-card-row"><section class="singlecard">'
    + '<div  class="card">'
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">'
     + ' <img src="../images/tarot_01.png" />'
      + '</figure>'
      + '<div class="info-card">'
      	+ '<h3>  Tình yêu </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
    + '</div>'
	+'<h3 class="card-h3"></h3>'
 + ' </section>'
  + '<section class="singlecard">'
    + '<div  class="card">'
     + ' <figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">    '  	
      + '<img src="../images/tarot_02.png" />'
     + ' </figure>'
     + '  <div class="info-card">'
      + '	<h3>  Thiên đạo </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
 + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
  + ' <div class="info-tarot">'  	
 + ' </div>'
 + '</div>' 
  +'	<div class="tarot-card-row"><section class="singlecard">'
   + '<div  class="card">'
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">'
     + ' <img src="../images/tarot_01.png" />'
      + '</figure>'
      + '<div class="info-card">'
      	+ '<h3>  Tình yêu </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
    + '</div>'
	+'<h3 class="card-h3"></h3>'
 + ' </section>'
  + '<section class="singlecard">'
    + '<div  class="card">'
     + ' <figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">    '  	
      + '<img src="../images/tarot_02.png" />'
     + ' </figure>'
     + '  <div class="info-card">'
      + '	<h3>  Thiên đạo </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
 + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
   + ' <div class="info-tarot">'  	
 + ' </div>'
 +'</div>'
+ '  </div>'

	},
		
	{
		title: 'Nhập Tarot_04',
		image: 'template3.gif',
		description: 'Điền theo mẫu',
		html: 
		
		'<div class="tarot-card"><h2 class="card-h2"></h2><div class="tarot-card-row"><section class="singlecard">'
    + '<div  class="card">'
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">'
     + ' <img src="../images/tarot_01.png" />'
      + '</figure>'
      + '<div class="info-card">'
      	+ '<h3>  Tình yêu </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
    + '</div>'
	+'<h3 class="card-h3"></h3>'
 + ' </section>'
  + '<section class="singlecard">'
    + '<div  class="card">'
     + ' <figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">    '  	
      + '<img src="../images/tarot_02.png" />'
     + ' </figure>'
     + '  <div class="info-card">'
      + '	<h3>  Thiên đạo </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
 + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
  + ' <div class="info-tarot">'  	
 + ' </div>'
 + '</div>' 
  +'<h2 class="card-h2"></h2>	<div class="tarot-card-row"><section class="singlecard">'
   + '<div  class="card">'
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">'
     + ' <img src="../images/tarot_01.png" />'
      + '</figure>'
      + '<div class="info-card">'
      	+ '<h3>  Tình yêu </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
    + '</div>'
	+'<h3 class="card-h3"></h3>'
 + ' </section>'
  + '<section class="singlecard">'
    + '<div  class="card">'
     + ' <figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">    '  	
      + '<img src="../images/tarot_02.png" />'
     + ' </figure>'
     + '  <div class="info-card">'
      + '	<h3>  Thiên đạo </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
 + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
   + ' <div class="info-tarot">'  	
 + ' </div>'
 +'</div>'
 +'<h2 class="card-h2"></h2>	<div class="tarot-card-row"><section class="singlecard">'
   + '<div  class="card">'
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">'
     + ' <img src="../images/tarot_01.png" />'
      + '</figure>'
      + '<div class="info-card">'
      	+ '<h3>  Tình yêu </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
    + '</div>'
	+'<h3 class="card-h3"></h3>'
 + ' </section>'
  + '<section class="singlecard">'
    + '<div  class="card">'
     + ' <figure class="front"><img src="../images/tarot.png" /></figure>'
      + '<figure class="back">    '  	
      + '<img src="../images/tarot_02.png" />'
     + ' </figure>'
     + '  <div class="info-card">'
      + '	<h3>  Thiên đạo </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
      + '</div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
 + ' <section class="singlecard">'
   + ' <div class="card">    '
      + '<figure class="front"><img src="../images/tarot.png" /></figure>'
     + ' <figure class="back">'
    + ' <img src="../images/tarot_03.png" />'
     + ' </figure>'
      + '<div class="info-card">'
      	+ '<h3>  Đường đời </h3>'
  		+ 'Có những lúc cần một người ở bên, bạn cũng được mà yêu cũng được...<br /> Ước có một người cùng thức mỗi đêm, chia sẻ nỗi niềm để thôi không buồn chán, ước có một người cùng ăn bữa sáng, để thấy thì ra cũng đáng đợi từng ngày'
     + ' </div>'
   + ' </div>'
   +'<h3 class="card-h3"></h3>'
 + ' </section>'
   + ' <div class="info-tarot">'  	
 + ' </div>'
 +'</div>'
+ '  </div>'

	}

	]
} );
