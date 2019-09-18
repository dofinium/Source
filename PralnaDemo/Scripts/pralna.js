


function loadWorkerServicesToClients(workerId, serviceType, valueType)
{
    $('#servicesList_div').load('/Statistic/ServicesList', { workerId: workerId, serviceType: serviceType, valueType: valueType });

}


function activateTicketButton()
{        
    $('#temporaryTicketSelector').fadeIn(150);
}


function deactivateTicketButton()
{
    $('#temporaryTicketSelector').fadeOut(150);
 
  //  $('#temporaryTicketSelector').removeClass('activated');
}

function ifTicketEntered()
{
    if ($('#ticketNumber').val().length != 6)
    {
        showNotifyError('Будь ласка, вкажить номер квитка або виберіть зі списку');
        $('#ticketSelectorContainer').addClass('has-error');

        setTimeout('activateTicketButton();', 100);
        setTimeout('deactivateTicketButton();', 300);
        setTimeout('activateTicketButton();', 500);
        setTimeout('deactivateTicketButton();', 700);
        setTimeout('activateTicketButton();', 900);
        setTimeout('deactivateTicketButton();', 1100);
        setTimeout('activateTicketButton();', 1300);

      /*  setTimeout('showTicketsList();', 500);
        setTimeout('hideTicketsList();', 900);

        setTimeout('showTicketsList();', 1200);
        setTimeout('hideTicketsList();', 1600);
        */

        setTimeout('showTicketsList();', 1800);


       

    }
}


function selectPlus()
{
    hideTicketsList();
    $('.feedbackSelector').removeClass('selected');
    $('.feedbackSelector').removeClass('notSelected');
    $('.plusSelector').addClass('selected');
    $('.minusSelector').addClass('notSelected');
    $('#plusNote').addClass('selected');
    $('#plusNote').removeClass('notSelected');

    $('#minusNote').addClass('notSelected');
    $('#minusNote').removeClass('selected');


    if ($('#ticketNumber').val().length == 6)
    {
        checkTicketNumber();
    }
    else
    {
        ifTicketEntered();
    }
}

function selectMinus()
{
    hideTicketsList();
    $('.feedbackSelector').removeClass('selected');
    $('.feedbackSelector').removeClass('notSelected');

    $('.minusSelector').addClass('selected');
    $('.plusSelector').addClass('notSelected');

    $('#minusNote').addClass('selected');
    $('#minusNote').removeClass('notSelected');
    $('#plusNote').addClass('notSelected');
    $('#plusNote').removeClass('selected');

    if ($('#ticketNumber').val().length == 6)
    {
        checkTicketNumber();
    }
    else
    {
        ifTicketEntered();
    }
}



function checkTicketNumber()
{
    var currentLength  =$('#ticketNumber').val().length ;

    if (currentLength < 6)
    {
        $('#statusLabel').text('Залишилось ' + (6 - currentLength) + ' литер');
        return;
    }
    else if(getValue() != 0)
    {
        $('#statusLabel').text('');
    }
    else if (getValue() == 0)
    {
        $('#statusLabel').text('Будь ласка, вкажіть, чи задоволені Ви якістю послуги.');
    }

   
    $('#serviceDetails').load('/ServiceToClient/GetData', { key: $('#ticketNumber').val() }, function ()
    {
        if (getValue() == 0)
        {            
            return;
        }

        setFeedbackValue();
    });
}

function getValue()
{
    var value = 0;

    if ($('.plusSelector.selected').length > 0)
    {
        value = 1;
    }
    else if ($('.minusSelector.selected').length > 0)
    {
        value = -1;
    }

    return value;
}

function setFeedbackValue()
{
    var ticketNumber = $('#ticketNumber').val();
    if (ticketNumber.length < 6)
    {
        return;
    }

    var value = getValue();
    
    $.post('/Feedback/SetValue', { ticketNumber: ticketNumber, value: getValue() }, function (response)
    {
        if (response == false)
        {
            showNotifyError('Квиток не знайдено...')
            return;
        }
        
        if (value == -1)
        {
            showFeedbackDetailsForm();
        }
        else
        {
            showThankYouMessageAndRedirectToFinalScreen();
        }
    });
}

function showThankYouMessageAndRedirectToFinalScreen()
{
    $('#resultMessage').hide();
    $('#resultMessage').get(0).innerHTML = 'Оцінку збережено.';

    $('#resultMessage').fadeIn(50, function ()
    {
        $('#feedbackForm_container').fadeOut(200);
        /*
        $('#serviceDetails').delay(500).slideUp(100, function ()
        {            
            $('#feedbackTable').fadeOut(100);
        });
        */
    });

    setTimeout("showThankyouForm();", 2500);
    setTimeout("location.href = '/Feedback/ThankyouForm';", 2000);

}

    function showFeedbackDetailsForm(id)
    {
        $('#feedbackForm_container').load('/Feedback/ShowFeedbackForm', { key: $('#ticketNumber').val() }, function ()
        {
            autosizeTextAreas();
            $('#feedbackForm_container').show(100);
        })
    }

    function setOtherViolation()
    {
        if ($('#otherViolationType').is(':checked') == true)
        {
            $('#commentForViolation_div').show(100);
        }
        else
        {
            $('#commentForViolation_div').hide(100);
        }
    }

    function showThankyouForm()
    {
        
        showThankYouMessageAndRedirectToFinalScreen();     
               
    }
  
    function saveFeedback(id)
    {
        $('#ClientValue').val(getValue());
       
        $.ajax({
            url: '/Feedback/Submit',
            type: 'post',
            dataType: 'json',
            data: $('#feedbackForm').serialize(),
            success: function (data)
            {
                if (data == 1)
                {
                    showThankyouForm();
                }
                
            }
        });

    }

    function deleteFeedback(id)
    {
        $.post('/Feedback/Delete', { id: id }, function (response)
        {
            clearScreen();
            showNotifySuccess('Відгук було видалено але Ви взмозі зробити це пізніше.');
            setTimeout("location.href = '/Feedback';", 3000);
        });
    }


    function setViolation(serviceId, violationTypeId)
    {
        $.post('/Feedback/SetVoilation', {serviceId: serviceId, violationTypeId: violationTypeId})
    }


    function selectTicketFromList(ticketNumber)
    {
        $('#ticketNumber').val(ticketNumber);
        $('#ticketsList_container').hide(100);
        checkTicketNumber();
    }


    function clearScreen()
    {

        $('#ticketNumber').val('');
        $('#serviceDetails').get(0).innerHTML = '';
        $('#feedbackForm_container').get(0).innerHTML = '';
        $('#resultMessage').get(0).innerHTML = '';
        $('.plusSelector').removeClass('selected');
        $('.minusSelector').removeClass('selected');
        $('.plusSelector').removeClass('notSelected');
        $('.minusSelector').removeClass('notSelected');
    }

    function showTicketsList()
    {
        //$('#temporaryTicketSelector').tooltip('hide');
        //$('#temporaryTicketSelector').removeAttr('data-toggle');

        clearScreen();
        $('#ticketsList_container').load('/Feedback/TicketsList', function ()
        {
            $('#ticketsList_container').slideDown(200);
        });
    }


    function hideTicketsList()
    {
        //$('#temporaryTicketSelector').tooltip('hide');
        //$('#temporaryTicketSelector').removeAttr('data-toggle');
                
            $('#ticketsList_container').slideUp(200);
       
    }
