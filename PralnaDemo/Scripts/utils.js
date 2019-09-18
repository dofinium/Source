
// for automated refresh video until it is uploads or events for History and Monitoring page and for Statuses
var autorefreshTimer;


function playNotGecko(name)
{
    name = "/Sounds/" + name;

    $('#message_sound').remove();
    return $("<div id='message_sound' class='bgSound' style='background-color: green; padding: 0px;'><embed src='" + name + ".mp3' hidden='true' autostart='true' loop='false' class='playSound'>" + "<audio autoplay='autoplay' style='display:none;' controls='controls'><source src='" + name + ".mp3' /><source src='" + name + ".ogg' /></audio></div>").appendTo('body');

    // sometime sound plays not in window open time, but when window closes    
  //  return $('<div id="message_sound" class="bgSound" style="background-color: green; padding: 0px;"><embed src="' + name + '.mp3" autostart="true" loop="false"></div>').appendTo('body');
}


function playSoundUniversal(name)
{
    playNotGecko(name);
    return;

    name = "/Sounds/" + name;
    $('#message_sound').remove();
    return $('<div id="message_sound" class="bgSound" style="background-color: green; padding: 0px;"><embed src="' + name + '.wav" autostart="true" loop="false"></div>').appendTo('body');
	//$.playSoundUniversal('/Sounds/' + name);
}

function playSound(name)
{

    playNotGecko(name);
    return;

	//$.playSound('/Sounds/' + name);
	/*
	$('<audio id="message_sound"><source src="/plugins/sound/' + name + '.wav" type="audio/wav"></audio>').appendTo('body');
	$('#message_sound')[0].play();
	*/
}

function getRandomstring()
{
    return Math.random().toString(36).replace(/[^a-z]+/g, '').substr(0, 7);
}

// someDate in format dd/mm/yyyy need return as yyyy/mm/dd
function reformatDate(someDate)
{
    someDate = someDate.replace('.', '/');
    var someDateAsArray = someDate.split('/');
    return someDateAsArray[2] + '/' + someDateAsArray[1] + '/' + someDateAsArray[0];     
}

function formatDate(d)
{   
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    if (dd < 10)
    {
        dd = '0' + dd
    }

    if (mm < 10)
    {
        mm = '0' + mm
    }
    var curr_year = d.getFullYear();
    //return dd + '/' + mm + '/' + curr_year;
    return curr_year + '/' + mm + '/' + dd;
}


function fixTime(selector)
{   
    var unparsedString = selector.val();
    var parsedString = unparsedString.replace('.', ':').replace(',', ':');
    selector.val(parsedString);
}

function TimeNow()
{
    var d = new Date();   
    var hh = d.getHours();
    var m = d.getMinutes();
    if (m < 10)
    {
        m = '0' + m
    }
    return hh + ':' + m;
}

function hideModalWindow()
{
	/*
	if (autorefreshTimer != null)
	{ // timer for refresh video link until it not uploaded up to end		
		clearTimeout(autorefreshTimer);
	}
*/

		
	$('.modal').modal('hide');
	$('.modal').html('');
	$('#modal-container').get(0).innerHTML = '';
	$('#modal-container').html('');
}


function disableButton(selector)
{
    $(selector).attr('disabled', 'disabled');    
}

function enableButton(selector)
{
    $(selector).removeAttr('disabled');
}


function autosizeTextAreas()
{  
    $('textarea').autosize({ append: "\n" });

    $('textarea').on('focus', function ()
    {
        $(this).autosize({ append: "\n" });
    });

}

function disableAjaxLoadBlocker()
{
	//$(document).ajaxSend(null);

	//$(document).ajaxComplete(null);
}

    $(function()
    {
        $(document).ajaxSend(function (event, request, settings)
        {
            $('#blocker').delay(500).fadeIn(1);
        });

        $(document).ajaxComplete(function (event, request, settings)
        {
            $('#blocker').fadeOut(1);

        });

        autosizeTextAreas();
        $('[data-toggle="tooltip"]').tooltip();
    });


function fnKeepSessionAlive()
{
    var myurl = "/Account/ActivateSession";

    if (window.XMLHttpRequest)
    {
        xhttp = new XMLHttpRequest()
    }
    else
    {
        xhttp = new ActiveXObject("Microsoft.XMLHTTP")
    }
    xhttp.open("GET", myurl, true);
    xhttp.send("");

    window.setTimeout("fnKeepSessionAlive();", 300000);
}

// it does not have backend part yet
function isDoubleUsesDot()
{

    var result = null;

    $.ajax(
    {
        url: '/Utils/DoubleFormatter/GetDivider',
        async: false,
        dataType: 'text',
        type: 'GET',
        success: function (data)
        {
            result = data;
        }
    });

    if (result == '.')
    {
        return true;
    }
    else
    {
        return false;
    }

    alert(result);

}

function fixDouble(id)
{
    // if (doubleUsesDot)
    if (isDoubleUsesDot())
    {
        $('#' + id).val($('#' + id).val().replace(',', '.'));
    }
    else
    {
        $('#' + id).val($('#' + id).val().replace('.', ','));
    }
}

function unescapeHtml(someString)
{
    var result = decodeURIComponent(someString).replace(/\n/g, '<br>');
    return result;
}

function showNotifySuccess(message)
{
    $.notify(message, "success");
}

function showNotifyError(message)
{
    $.notify(message, "error");
}

function showNotifyWarn(message)
{
    $.notify(message, "warn");
}

function showNotifyInfo(message)
{
    $.notify(message, "info");
}


function getRandomTime()
{
    var someTime = new Date();
    var result = someTime.toISOString() + '.' + someTime.getMilliseconds(); 
    return result;
}

