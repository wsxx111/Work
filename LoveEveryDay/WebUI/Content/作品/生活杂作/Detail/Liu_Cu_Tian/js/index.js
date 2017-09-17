 /*绑定事件*/
        function addEvent(obj, sType, fn) {
            if (obj.addEventListener) {
                obj.addEventListener(sType, fn, false);
            } else {
                obj.attachEvent('on' + sType, fn);
            }
        };
        function removeEvent(obj, sType, fn) {
            if (obj.removeEventListener) {
                obj.removeEventListener(sType, fn, false);
            } else {
                obj.detachEvent('on' + sType, fn);
            }
        };
        function prEvent(ev) {
            var oEvent = ev || window.event;
            if (oEvent.preventDefault) {
                oEvent.preventDefault();
            }
            return oEvent;
        }  
		function moveLogin(id)
		{
		var oImg = document.getElementById(id);
            /*拖拽功能*/
            (function () {
                addEvent(oImg, 'mousedown', function (ev) {
                    var oEvent = prEvent(ev),
                    oParent = oImg.parentNode,
                    disX = oEvent.clientX - oImg.offsetLeft,
                    disY = oEvent.clientY - oImg.offsetTop,
                    startMove = function (ev) {
                        if (oParent.setCapture) {
                            oParent.setCapture();
                        }
                        var oEvent = ev || window.event,
                        l = oEvent.clientX - disX,
                        t = oEvent.clientY - disY;
                        oImg.style.left = l + 'px';
                        oImg.style.top = t + 'px';
                        elemLeft.value = l;
                        elemRight.value = t;
                        oParent.onselectstart = function () {
                            return false;
                        }
                    }, endMove = function (ev) {
                        if (oParent.releaseCapture) {
                            oParent.releaseCapture();
                        }
                        oParent.onselectstart = null;
                        removeEvent(oParent, 'mousemove', startMove);
                        removeEvent(oParent, 'mouseup', endMove);
                    };
                    addEvent(oParent, 'mousemove', startMove);
                    addEvent(oParent, 'mouseup', endMove);
                    return false;
                });
            })();               

		}	
$(document).ready(function(){

moveLogin('oImg');
moveLogin('qqBody');
moveLogin('qqChat');
 $('#QQSpace').click(function(){
    $("#QSHref").click();
  });
  $('.qq-xuan li').click(function(){
    $(this).addClass('qq-xuan-li').siblings().removeClass('qq-xuan-li')
  })
  $('.qq-hui-txt').hover(function(){
    var aa = $(this).html()
    $('.qq-hui-txt').attr('title',aa)
  })
  $('.login-close').click(function(){
     $(this).parent().parent().css('display','none')
  })
  $('.qq-hui li').dblclick(function(){
    $('.qq-chat').css('display','block').removeClass('mins')
	$('.qq-chat-t-name').html($(this).find('span').html())
	$('.qq-chat-t-head img').attr('src',$(this).find('img').attr('src'))
	$('.qq-chat-you span').html($(this).find('span').html())
	$('.qq-chat-you i').html($(this).find('.qq-hui-name i').html())
	$('.qq-chat-ner').html($(this).find('.qq-hui-txt').html())
	$("#qq-chat-text").trigger("focus")
	$('.my').remove()
  })
  $('.qq-exe img').dblclick(function(){
    $('.qq-login').css('display','block').removeClass('mins')
  })
  $('.login-but').click(function(){
	if($('.login-txt').find('input').val() == ''){
	  alert('请输入账号或者密码')
	}else if($('login-txt input').val() != ''){
      $('.qq').css('display','block').removeClass('mins')
	  $('.qq-login').css('display','none')
	}
  })
  $('.login-txt input').keydown(function(e){
    if(e.keyCode == 13){
      if($('.login-txt').find('input').val() == ''){
	  alert('请输入账号或者密码')
	}else if($('login-txt input').val() != ''){
      $('.qq').css('display','block').removeClass('mins')
	  $('.qq-login').css('display','none')
	}
    }
  })
  $('.close').click(function(){
    $(this).parent().parent().parent().css('display','none')
  })
  $('.min').click(function(){
    $(this).parent().parent().parent().addClass('mins')
  })
  $('.qq .close').click(function(){
    $('.qq-chat').css('display','none')
  })
  $('#qq-chat-text').keydown(function(e){
    if(e.keyCode == 27){
	  $('.qq-chat').css('display','none')
    }
  })
  $('.fasong').click(function(){
	if($('#qq-chat-text').val()==''){
	  alert("发送内容不能为空,请输入内容")
	}else if($('#qq-chat-text').val()!=''){
      var name = $('.qq-top-name span').html()
	  var ner = $('#qq-chat-text').val()
	  var ners = ner.replace(/\n/g,'<br>')
	  var now=new Date()
      var t_div = now.getFullYear()+"-"+(now.getMonth()+1)+"-"+now.getDate()+' '+now.getHours()+":"+now.getMinutes()+":"+now.getSeconds();
	  $('.qq-chat-txt ul').append('<li class="my"><div class="qq-chat-my"><span>'+name+'</span><i>'+t_div+'</i></div><div class="qq-chat-ner">'+ners+'</div></li>')
	  $(".qq-chat-txt").scrollTop($(".qq-chat-txt")[0].scrollHeight);
	  $('#qq-chat-text').val('').trigger("focus")
	}
  })
  $('.close-chat').click(function(){
    $('.qq-chat').css('display','none')
  })
  $(".qq-hui").niceScroll({
    touchbehavior:false,cursorcolor:"#ccc",cursoropacitymax:1,cursorwidth:6,horizrailenabled:true,cursorborderradius:3,autohidemode:true,background:'none',cursorborder:'none'
  });
});