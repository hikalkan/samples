(function ($) {
  var history = {
    results: [],
  };

  var selectedPerson1 = null;
  var selectedPerson2 = null;
  var selectedWomen = null; //The name that was announced by the presenter
  var lastResult = null;

  function getRandomPerson() {
    return personNames[Math.floor(Math.random() * 1000)];
  }

  function selectPersons() {
    do {
      //Select person 1
      selectedPerson1 = getRandomPerson();
      //Select person 2
      do {
        selectedPerson2 = getRandomPerson();
        //Should be a different person
      } while (selectedPerson2 == selectedPerson1);
      //Should not be "E" & "E" (double man)
    } while (selectedPerson1.sex === "E" && selectedPerson2.sex === "E");  
    //Select the sample woman
    selectedWomen = getOneSelectedWomen();
  }

  function getOneSelectedWomen() {
    if (selectedPerson1.sex === "E") {
      return selectedPerson2;
    } else if (selectedPerson2.sex === "E") {
      return selectedPerson1;
    }

    //Both women, so get a random one:
    if (Math.random() < 0.5) {
      return selectedPerson1;
    } else {
      return selectedPerson2;
    }
  }

  function getGameMode(){
    return $('#GameMode').val();
  }

  function setPresenterMessage() {
    var gameMode = getGameMode();
    var message = "Kapıların en az birisinin arkasında KADIN"
    if(gameMode !== "HiddenName"){
      message = message + " (adı " + selectedWomen.name + ")" ;
    }

    message = message + " vardır. Bu durumda, sizce her iki kapıda da kadın mı vardır yoksa kapıların birisinde erkek birisinde kadın mı vardır?";
    $("#PresenterMessage").text(message);

    $('#Kapi1Name').text('?');
    $('#Kapi2Name').text('?');

    if(gameMode === "OpenDoor"){
      if(selectedPerson1 === selectedWomen){
        $('#Kapi1Name').text(selectedWomen.name);
      } else {
        $('#Kapi2Name').text(selectedWomen.name);
      }
    }
  }

  function refreshGame() {
    selectPersons();
    setPresenterMessage();
    console.log(selectedPerson1);
    console.log(selectedPerson2);
  }

  function isSelectionTrue(selection) {
    if (selection === "E") {
      //One woman one man (so one of the persons should be man)
      return selectedPerson1.sex === "E" || selectedPerson2.sex === "E";
    } else {
      //Both women
      return selectedPerson1.sex === "K" && selectedPerson2.sex === "K";
    }
  }

  function applySelection(selection) {
    var date = new Date();
    lastResult = {
      selectedWomen: selectedWomen,
      selectedPerson1: selectedPerson1,
      selectedPerson2: selectedPerson2,
      userSelection: selection,
      isTrue: isSelectionTrue(selection),
      date: date.toLocaleDateString() + " " + date.toLocaleTimeString(),
    };
    history.results.unshift(lastResult);
    refreshHistory();
    refreshGame();
  }

  function refreshHistory() {
    var $historyTableBody = $("#HistoryTable tbody");
    $historyTableBody.empty();

    var twoWomanCount = 0;
    var oneWomanOneManCount = 0;
    var twoWomanAnswerCount = 0;
    var twoWomanAnswerTrueCount = 0;
    var oneWomanOneManAnswerCount = 0;
    var oneWomanOneManAnswerTrueCount = 0;
    for (var i = 0; i < history.results.length; i++) {
      var result = history.results[i];
      if (i < 100) {
        $historyTableBody.append(
          $(
            "<tr><td>" +
              result.date +
              "</td><td>" +
              result.selectedPerson1.name +
              " (" +
              result.selectedPerson1.sex +
              ") & " +
              result.selectedPerson2.name +
              " (" +
              result.selectedPerson2.sex +
              ")" +
              "</td><td>" +
              (result.userSelection === "E" ? "1E+1K" : "2K") +
              "</td><td>" +
              (result.isTrue
                ? "<span class='true-result'>DOĞRU</span>"
                : "<span class='false-result'>YANLIŞ</span>") +
              "</td></tr>"
          )
        );
      }

      if (
        result.selectedPerson1.sex === "E" ||
        result.selectedPerson2.sex === "E"
      ) {
        oneWomanOneManCount++;
        if (result.userSelection === "E") {
          oneWomanOneManAnswerTrueCount++;
        }
      } else {
        twoWomanCount++;
        if (result.userSelection === "K") {
          twoWomanAnswerTrueCount++;
        }
      }

      if (result.userSelection === "E") {
        oneWomanOneManAnswerCount++;
      } else {
        twoWomanAnswerCount++;
      }
    }

    var total = oneWomanOneManCount + twoWomanCount;
    $("#StatTotalGame").text(total);
    $("#Stat2Woman").text(
      twoWomanCount + " (%" + ((twoWomanCount * 100.0) / total).toFixed(2) + ")"
    );
    $("#Stat1Women1Man").text(
      oneWomanOneManCount +
        " (%" +
        ((oneWomanOneManCount * 100.0) / total).toFixed(2) +
        ")"
    );

    var twoWomenAnswerTrueRatio = 0.0;
    if (twoWomanAnswerCount > 0) {
      twoWomenAnswerTrueRatio =
        (twoWomanAnswerTrueCount * 100.0) / twoWomanAnswerCount;
    }

    var oneWomanOneManAnswerTrueRatio = 0.0;
    if (oneWomanOneManAnswerCount > 0) {
      oneWomanOneManAnswerTrueRatio =
        (oneWomanOneManAnswerTrueCount * 100.0) / oneWomanOneManAnswerCount;
    }

    $("#Stat2WomanAnswer").text(
      twoWomanAnswerCount +
        " (%" +
        twoWomenAnswerTrueRatio.toFixed(2) +
        " doğru)"
    );
    $("#Stat1Women1ManAnswer").text(
      oneWomanOneManAnswerCount +
        " (%" +
        oneWomanOneManAnswerTrueRatio.toFixed(2) +
        " doğru)"
    );

    if (lastResult != null) {
      $("#StatSelectedWomen").text(lastResult.selectedWomen.name);
      $("#StatUserSelection").text(
        lastResult.userSelection === "E" ? "1 Erkek + 1 Kadın" : "2 Kadın"
      );
      $("#StatSelectedPeople").text(
        lastResult.selectedPerson1.name +
          " (" +
          lastResult.selectedPerson1.sex +
          ") & " +
          lastResult.selectedPerson2.name +
          " (" +
          lastResult.selectedPerson2.sex +
          ")"
      );
      $("#StatResult").html(
        lastResult.isTrue
          ? "<span class='true-result'>DOĞRU</span>"
          : "<span class='false-result'>YANLIŞ</span>"
      );
    }
  }

  $(function () {
    refreshGame();

    $("#DoubleWomenButton").click(function () {
      applySelection("K");
    });

    $("#OneWomenOneManButton").click(function () {
      applySelection("E");
    });

    $("#MultipleDoubleWomenButton").click(function () {
      var count = parseInt($("#MultipleGameCount").val());
      for (var i = 0; i < count; i++) {
        applySelection("K");
      }
    });

    $("#MultipleOneWomenOneManButton").click(function () {
      var count = parseInt($("#MultipleGameCount").val());
      for (var i = 0; i < count; i++) {
        applySelection("E");
      }
    });

    $('#GameMode').change(function(){
      setPresenterMessage();
    });
  });
})(jQuery);
