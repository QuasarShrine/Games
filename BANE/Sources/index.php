<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>The Bane</title>
        <!-- Latest compiled and minified JavaScript -->
        <script
            src="https://code.jquery.com/jquery-3.1.1.min.js"
            integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8="
        crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

        <!-- Latest compiled and minified CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

        <!-- Optional theme -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

        <link rel="stylesheet" type="text/css" media="all" href="main.css" />
    </head>
    <body>
        <div class="content text-center">
            <h4 class="">
                BANE
            </h4>
            <div id="display">

                <div id="views">
                    <img src="../Graphics/Rooms/room_straight.png" alt="Loading" id="imageView" />
                </div>
                <div id="map">
                </div>
                <div id="inventory">
                    <table class="invTab">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Type</th>
                                <th>Descr.</th>
                                <th>Qte.</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>

                </div>
            </div>
            <div>
                <div id="console">
                </div>
            </div>

            <div class="buttons text-center">
                <div class="movements">
                    <button type="button" class="btn btn-default" id="turnLeft"><span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span></button>
                    <button type="button" class="btn btn-default" id="goFront"><span class="glyphicon glyphicon-arrow-up" aria-hidden="true"></span></button>
                    <button type="button" class="btn btn-default" id="turnRight"><span class="glyphicon glyphicon-arrow-right" aria-hidden="true"></span></button>
                </div>
                <div class="row">
                    <div class="infos col-xs-4">
                        <span id="long"></span>
                        <span id="lat"></span>
                    </div>
                    <div class="actions col-xs-8">
                        <button type="button" class="btn btn-default" id="atk">ATK</button>
                        <button type="button" class="btn btn-default" id="def">DEF</button>
                        <button type="button" class="btn btn-default" id="inv">INV</button>
                        <button type="button" class="btn btn-default" id="mapBtn">MAP</button>
                        <button type="button" class="btn btn-default" id="resetBtn">RESET</button>
                    </div>
                </div>
            </div>

        </div>

        <script type="text/javascript" src="main.js"></script>
    </body>
</html>
