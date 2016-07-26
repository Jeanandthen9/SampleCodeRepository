$(document)
    .ready(function() {
       $('#storyInfo').hide();
                });
         $('#moreInfo')
            .on("click",
                function showInfo() {
                    $('#storyInfo').show();
                    $('#moreInfo').hide();
                });
        
        $('#lessInfo')
            .on("click",
                function hideInfo() {
                    $('#storyInfo').hide();
                    $('#moreInfo').show();
    });