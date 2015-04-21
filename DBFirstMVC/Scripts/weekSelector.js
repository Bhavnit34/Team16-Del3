var selectedItems = [];		// Holds all selectable elements which are already selected
var numSelecting = 0;		// Keep count of how many elements we have selected during selecting event
var selectAll = false;
var removeAll = false;
$(document).ready(function ()		// Execute all of this on load 
{
    // Add week selector	


    $("#popupWeeks").bind("mousedown", function (e) {
        e.metaKey = true;		// Simulates holding down control to select non-adjacent elements
    }).selectable(
	{
	    selecting: function (e, ui) {
	        var clickedText = ui.selecting.innerHTML;

	        if (numSelecting == 0)		// If this is the first element being selected
	        {
	            // If element is not already selected, we now add all other elements we later select
	            if (selectedItems.indexOf(clickedText) == -1) {
	                selectAll = true;
	                removeAll = false;
	            }
	            else	// If element is already selected, then we remove all other elements we later select
	            {
	                selectAll = false;
	                removeAll = true;
	            }
	        }

	        // If element is not selected, add it to array
	        if (selectAll) {
	            selectedItems.push(clickedText);
	        }

	        if (removeAll)	// If element is already selected, then remove it from the array and remove it's class
	        {
	            selectedItems.splice(selectedItems.indexOf(clickedText), 1);
	            ui.selecting.className = "ui-state-default myCircle";
	        }

	        // Move on to the next element
	        numSelecting++;
	    },

	    stop: function () {
	        // Reset selectedItems and numSelecting to 0
	        selectedItems.length = 0;
	        numSelecting = 0;
	        var selectAll = false;
	        var removeAll = false;

	        // For every selected element, add it to the array
	        $(".ui-selected", this).each(function () {
	            selectedItems.push(this.innerHTML);
	        });
	    },

	    distance: 1			// This is so we can register normal mouse click events
	});

    // Since the distance on the selectable is now greater than zero, clicks do not work if the mouse does not move
    // Simulate mouse click like the selector would normally
    $("#popupWeeks li").click(function () {
        var clickedText = $(this).text();

        // If element is not selected, add it to array and add selected class
        if (selectedItems.indexOf(clickedText) == -1) {
            $(this).addClass('ui-selected');
            selectedItems.push(clickedText);
            $('#selectedWeeks').val(selectedItems.join(","));
        }
        else 	// If element is already selected, then remove it from the array and remove selected class
        {
            $(this).removeClass('ui-selected');
            $(this).addClass('ui-selectee');
            $(this).addClass('myCircle');
            selectedItems.splice(selectedItems.indexOf(clickedText), 1);
            $('#selectedWeeks').val(selectedItems.join(","));
        }
    });
});