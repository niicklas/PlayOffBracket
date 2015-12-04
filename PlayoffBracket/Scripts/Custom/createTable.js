window.onload = function () {
    //createButton(document.getElementById('content'));
    //addColumn();
    //addRow();
    $("#tabell").hide();
    $("#nameTable").hide();
    $('#start-button').on('click', function (e) {

        // Hämta innehållet i inmatningsfältet
        var nrOfTeams = +$('#amountOfPlayers').val();
        
        enterTeamName(nrOfTeams);

        //printTable(nrOfTeams);
       // var players = getPlayers(nrOfTeams);

        //alert(players[0]);
        //printSchedule(players);
    }); 

}

function enterTeamName(nrOfTeams) {
    if (nrOfTeams > 0) {
        $("#nameTable").show();
        $('#nameTable tbody').empty();
        
        //$(".jumbotron").hide();

        // Gå igenom alla lag
        for (var i = 1; i <= nrOfTeams; i++) {
            $('#nameTable tbody').append("<tr id='Player" + i + "'><td><input name='playerNames' type='text'  maxlength='100' placeholder='Player" + i + "'> </td></tr>");
        }
        $('#nameTable tbody').append("<button type='submit' class='btn btn-default' id='create-button' >Create table</button>");
    }
}

function printTable(nrOfTeams) {
    //alert(nrOfTeams);

    if (nrOfTeams > 0) {
        $("#tabell").show();
        $(".jumbotron").hide();

        // Gå igenom alla lag
        for (var i = 1; i <= nrOfTeams; i++) {
            $('#tabell tbody').append("<tr id='Player" + i + "'><td> Player" + i + "</td><td class='games'>0</td><td class='wins'>0</td><td class='ties'>0</td><td class='losses'>0</td><td class='scores'>0-0</td><td class='points'>0</td></tr>");
        }
    }
}

//Döper spelarna till Player1 osv..
function getPlayers(amountOfPlayers) {
    var players = [];
    for (var i = 0; i < amountOfPlayers; i++) {
        players.push("Player" + (i + 1));
    }
    return players;
}

function printSchedule(players) {
    //Om det är ojämnt antal lag
    //alert(players.length);
    if ((players.length)%2>0)
    {
        //alert((players.length)%2);
        for (var i = 0; i < players.length; i++)
        {
            $('#schedule').append("<br/><div><div style='font-size:17px'>Round" + (i + 1) + "</div></div>");

            for (var j = 0; j < (players.length / 2)-(players.length % 2) ; j++)
            {
                //$('#schedule tbody').append("<div class='game' id='" + i + j + "' style='background-color:whitesmoke'>");
                //$('#schedule').append("<div class='game'>");

                $('#schedule').append("<div class='game'><div><div class='col-md-9'><label for='round" + i + "" + players[(i + j * 2) % (players.length)] + "'>" + players[(i + j * 2) % (players.length)] + "</label></div><div class='col-md-3'><input type='text' class='poang' id='round" + i + "" + players[(i + j * 2) % (players.length)] + "' placeholder='0'></div></div><div><div class='col-md-9'><label for='round" + i + "" + players[(i + j * 2 + 1) % (players.length)] + "'>" + players[(i + j * 2 + 1) % (players.length)] + "</label></div><div class='col-md-3'><input type='text' class='poang' id='round" + i + "" + players[(i + j * 2 + 1) % (players.length)] + "' placeholder='0'></div></div></div>");
                
                //$('#schedule').append("<div><div class='col-md-9'><label for='round" + i + "" + players[(i + j * 2 + 1) % (players.length)] + "'>" + players[(i + j * 2 + 1) % (players.length)] + "</label></div><div class='col-md-3'><input type='text' class='poang' id='round" + i + "" + players[(i + j * 2 + 1) % (players.length)] + "' placeholder='0'></div></div></div>");

                //$('#schedule').append("</div>");
                //$('#schedule').append("<br/>");
            }
            //$('#schedule').append("<br/>");
        }
    }

    $('.poang').on('change paste keyup', function () {

        
        //$('#resultat').empty();
        // Hämta innehållet i inmatningsfältet
        //var score1 = $(this).closest('div').find('.poang').val();
        var score1 = $(this).closest('.game').find('.poang').val();
        var score2 = $(this).closest('.game').find('.poang').last().val();

        if (score1 != "" && score2 != "") {
        //alert(score1 + " " + score2);
            updateTable();
        }
    });

}

function updateTable() {

    var game = $('#schedule').find('.poang').last();
    alert(game.val());
    var i = 1;
    //while (game != "") {
    game = game.next();
        alert(game.val());
        i++;
        //game.find('Label').value();
        game = game.next();
    //}
}