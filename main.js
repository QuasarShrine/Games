//========= Init values ===============
//  ---- dynamic variables ---------
var MAXFLOORSIZE = 7; //size of the floor (square), in "room"
var displayTxt = "";
var PLAYER = null;

// floor matrice
var FLOOR = [
];
// init matrice
for (i = 0; i < MAXFLOORSIZE; i++) {
    FLOOR[i] = [
    ];
}

var CURRENTROOM = null;
var MAPHTML = "";

// ----- static variables -------
var VIEWSIMAGES = {
    straight: "../Graphics/Rooms/room_straight.png",
    right: "../Graphics/Rooms/room_right.png",
    left_right: "../Graphics/Rooms/room_left_right.png",
    left: "../Graphics/Rooms/room_left.png",
    front_left: "../Graphics/Rooms/room_front_left.png",
    front_right: "../Graphics/Rooms/room_front_right.png",
    freeway: "../Graphics/Rooms/room_freeway.png",
    bagend: "../Graphics/Rooms/room_bagend.png",
    wall: "../Graphics/Rooms/room_wall.png"
};


var MAPTILES = {
    bagend_up: "../Graphics/Rooms/bagend-up.png",
    bagend_right: "../Graphics/Rooms/bagend-right.png",
    bagend_down: "../Graphics/Rooms/bagend-down.png",
    bagend_left: "../Graphics/Rooms/bagend-left.png",
    straight_v: "../Graphics/Rooms/straight-vert.png",
    straight_h: "../Graphics/Rooms/straight-hori.png",
    right_up: "../Graphics/Rooms/right-up.png",
    left_up: "../Graphics/Rooms/left-up.png",
    right_down: "../Graphics/Rooms/left-down.png",
    left_down: "../Graphics/Rooms/left-down.png",
    threeways_up: "../Graphics/Rooms/3ways-up.png",
    threeways_right: "../Graphics/Rooms/3ways-right.png",
    threeways_down: "../Graphics/Rooms/3ways-down.png",
    threeways_left: "../Graphics/Rooms/3ways-left.png",
    freeway: "../Graphics/Rooms/freeway.png"
};

var ENEMIESTYPES = [
    'Giant rat',
    'Dog',
    'Wolf',
    'Kobold',
    'Gobelin',
    'Bear',
    'Ghoul',
    'Bandit',
    'Orc',
    'Werewolf',
    'Cursed Knight',
    'Necromancer',
    'Death Mage'
];
var ENEMIESMODIFERS = [
    'wounded',
    'normal',
    'starving',
    'enraged',
    'poison',
    'fire',
    'dark'
];


//======== listeners =============
$("#atk").on('click', function () {});
$("#def").on('click', function () {});
$("#turnLeft").on('click', function () {
    turnPlayerLeft(PLAYER);
    viewGenerate(CURRENTROOM, PLAYER);
});
$("#goFront").on('click', function () {
    movePlayerForward(PLAYER);
    viewGenerate(CURRENTROOM, PLAYER);
});
$("#turnRight").on('click', function () {
    turnPlayerRight(PLAYER);
    viewGenerate(CURRENTROOM, PLAYER);
});
$("#inv").on('click', function () {
    $("#map").hide();
    $("#inventory").toggle();
});
$("#mapBtn").on('click', function () {
    $("#inventory").hide();
    $("#map").toggle();
});
$("#resetBtn").on('click', function () {
    Init();
});
// ------------------------------------------------------------------
// --------------------------------------------


// ============ START MAIN SCRIPT =========================================
// ----------------------------------------------------------------------


// ===== INIT =====
function Init() {
    displayTxt = "";
    PLAYER = null;
    // floor matrice
    FLOOR = [
    ];
    // init matrice
    for (i = 0; i < MAXFLOORSIZE; i++) {
        FLOOR[i] = [
        ];
    }
    CURRENTROOM = null;
    MAPHTML = "";

    // ================================ INIT ============================

    // init dom element
    $('#map').html(MAPHTML);
    $("#map").hide();
    $("#inventory").hide();

    //init floor
    floorGenerate(MAXFLOORSIZE);
    PLAYER = new Player("Bane", 1);
    if (FLOOR[0][0].dirs_available[1] === true) {
        PLAYER.headedTo = 1;
    } else {
        if (FLOOR[0][0].dirs_available[2] === true) {
            PLAYER.headedTo = 2;
        }
    }
    CURRENTROOM = FLOOR[0][0];

    //init display
    viewGenerate(CURRENTROOM, PLAYER);
    generateMap();


}


//-----------------

$(function () { // DOM ready
    Init();
});
// -------------------- END MAIN SCRIPT---------------------------
// -----------------------------------------------------------------




//==============================================================================
// =========================== [ RESSOURCES ] ==================================
//==============================================================================

// ============ Utility Methods ================

//Generate floor
function floorGenerate(size) {
    FLOOR = [
    ];
    for (i = 0; i < MAXFLOORSIZE; i++) {
        FLOOR[i] = [
        ];
    }
    var xvar = 0;
    var yvar = 0;
    for (xvar = 0; xvar < size; xvar++) {
        for (yvar = 0; yvar < size; yvar++) {
            FLOOR[xvar][yvar] = new Room(xvar, yvar);
        }
    }
}

//Generate display view
function getRoomType(room) {
    var up = room.dirs_available[0];
    var right = room.dirs_available[1];
    var down = room.dirs_available[2];
    var left = room.dirs_available[3];

    up = up ? 1 : 0;
    right = right ? 3 : 0;
    down = down ? 5 : 0;
    left = left ? 7 : 0;

    var tot = up + right + down + left;

    return tot;
}

//Generate display view
function viewGenerate(room, player) {
    //var roomType = getRoomType(room);
    var ways = room.dirs_available;
    var headedTo = player.headedTo;
    var viewImage = null;

    if (ways[0] === true && ways[1] === false && ways[2] === true && ways[3] === false) { // straight up
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 1:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 2:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 3:
                viewImage = VIEWSIMAGES.wall;
                break;
        }
    }
    if (ways[0] === false && ways[1] === true && ways[2] === false && ways[3] === true) { // straight left-right
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 1:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 2:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 3:
                viewImage = VIEWSIMAGES.straight;
                break;
        }
    }

    if (ways[0] === false && ways[1] === true && ways[2] === false && ways[3] === true) { // straight left-right
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 1:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 2:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 3:
                viewImage = VIEWSIMAGES.straight;
                break;
        }
    }

    if (ways[0] === false && ways[1] === false && ways[2] === true && ways[3] === true) { // angle left-down
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 1:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 2:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 3:
                viewImage = VIEWSIMAGES.straight;
                break;
        }
    }
    if (ways[0] === false && ways[1] === true && ways[2] === true && ways[3] === false) { // angle right-down
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 1:
                viewImage = VIEWSIMAGES.front_right;
                break;
            case 2:
                viewImage = VIEWSIMAGES.front_left;
                break;
            case 3:
                viewImage = VIEWSIMAGES.wall;
                break;
        }
    }

    if (ways[0] === true && ways[1] === true && ways[2] === false && ways[3] === false) { // angle right-up
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 1:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 2:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 3:
                viewImage = VIEWSIMAGES.wall;
                break;
        }
    }

    if (ways[0] === true && ways[1] === false && ways[2] === false && ways[3] === true) { // angle left-up
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 1:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 2:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 3:
                viewImage = VIEWSIMAGES.straight;
                break;
        }
    }
    if (ways[0] === false && ways[1] === false && ways[2] === true && ways[3] === false) { // bagend-down
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.bagend;
                break;
            case 1:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 2:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 3:
                viewImage = VIEWSIMAGES.wall;
                break;
        }
    }
    if (ways[0] === false && ways[1] === true && ways[2] === false && ways[3] === false) { // bagend-right
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 1:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 2:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 3:
                viewImage = VIEWSIMAGES.bagend;
                break;
        }
    }
    if (ways[0] === true && ways[1] === false && ways[2] === false && ways[3] === false) { // bagend-up
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.straight;
                break;
            case 1:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 2:
                viewImage = VIEWSIMAGES.bagend;
                break;
            case 3:
                viewImage = VIEWSIMAGES.wall;
                break;
        }
    }
    if (ways[0] === false && ways[1] === false && ways[2] === false && ways[3] === true) { // bagend-left
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 1:
                viewImage = VIEWSIMAGES.bagend;
                break;
            case 2:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 3:
                viewImage = VIEWSIMAGES.straight;
                break;
        }
    }
    if (ways[0] === true && ways[1] === true && ways[2] === true && ways[3] === false) { // 3way up left down
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.front_right;
                break;
            case 1:
                viewImage = VIEWSIMAGES.freeway;
                break;
            case 2:
                viewImage = VIEWSIMAGES.front_left;
                break;
            case 3:
                viewImage = VIEWSIMAGES.wall;
                break;
        }
    }
    if (ways[0] === false && ways[1] === true && ways[2] === true && ways[3] === true) { // 3way left right down
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 1:
                viewImage = VIEWSIMAGES.front_right;
                break;
            case 2:
                viewImage = VIEWSIMAGES.freeway;
                break;
            case 3:
                viewImage = VIEWSIMAGES.front_left;
                break;
        }
    }
    if (ways[0] === true && ways[1] === false && ways[2] === true && ways[3] === true) { // 3way up left down
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.front_left;
                break;
            case 1:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 2:
                viewImage = VIEWSIMAGES.front_right;
                break;
            case 3:
                viewImage = VIEWSIMAGES.freeway;
                break;
        }
    }
    if (ways[0] === true && ways[1] === true && ways[2] === false && ways[3] === true) { // 3way up right down
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.freeway;
                break;
            case 1:
                viewImage = VIEWSIMAGES.front_left;
                break;
            case 2:
                viewImage = VIEWSIMAGES.wall;
                break;
            case 3:
                viewImage = VIEWSIMAGES.front_right;
                break;
        }
    }
    if (ways[0] === true && ways[1] === true && ways[2] === true && ways[3] === true) { // freeway
        switch (headedTo) {
            case 0:
                viewImage = VIEWSIMAGES.freeway;
                break;
            case 1:
                viewImage = VIEWSIMAGES.freeway;
                break;
            case 2:
                viewImage = VIEWSIMAGES.freeway;
                break;
            case 3:
                viewImage = VIEWSIMAGES.freeway;
                break;
        }
    }

    $("#imageView").attr("src", viewImage);
    $("#long").html("Long : " + room.x);
    $("#lat").html("Lat : " + room.y);

}

/**
 * change player direction left
 *
 * @param {type} player
 * @returns {undefined}
 */
function turnPlayerRight(player) {
    var headedTo = player.headedTo;
    headedTo++;
    if (headedTo >= 4) {
        headedTo = 0;
    }
    player.headedTo = headedTo;
}

/**
 * change player direction left
 *
 * @param {type} player
 * @returns {undefined}
 */
function turnPlayerLeft(player) {
    var headedTo = player.headedTo;
    headedTo--;
    if (headedTo <= -1) {
        headedTo = 3;
    }
    player.headedTo = headedTo;
}

/**
 * move player to the room he's facing
 *
 * @param {type} player
 * @returns {undefined}
 */

function movePlayerForward(player) {
    var headedTo = player.headedTo;
    var ways = CURRENTROOM.dirs_available;

    if (ways[headedTo] === true && headedTo === 0) {
        CURRENTROOM = FLOOR[CURRENTROOM.x][CURRENTROOM.y - 1];
    }
    if (ways[headedTo] === true && headedTo === 1) {
        CURRENTROOM = FLOOR[CURRENTROOM.x + 1][CURRENTROOM.y];
    }
    if (ways[headedTo] === true && headedTo === 2) {
        CURRENTROOM = FLOOR[CURRENTROOM.x][CURRENTROOM.y + 1];
    }
    if (ways[headedTo] === true && headedTo === 3) {
        CURRENTROOM = FLOOR[CURRENTROOM.x - 1][CURRENTROOM.y];
    }
}

/**
 * Generate map
 *
 * @return void
 */
function generateMap() {
    MAPHTML = "<table>";
    var xvar = 0;
    var yvar = 0;
    for (yvar = 0; yvar < MAXFLOORSIZE; yvar++) {
        MAPHTML += "<tr>";

        for (xvar = 0; xvar < MAXFLOORSIZE; xvar++) {
            MAPHTML += "<td>";

            MAPHTML += "<img src='" + FLOOR[xvar][yvar].mapTile + "' alt='x" + xvar + "_y" +
                    yvar + "'>";
            MAPHTML += "</td>";

        }
        MAPHTML += "</tr>";
    }
    MAPHTML += "</table>";
    $('#map').append(MAPHTML);
}



/**
 * random int between min and max
 *
 * @param {int} min
 * @param {int} max
 * @returns {int}
 */
function randomIntFromInterval(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

/**
 * Write in game console the "txt" texte
 *
 * @param {string} txt
 * @return void
 */
function writeConsole(txt) {
    var date = new Date();
    dateNow = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
    displayTxt += "[" + dateNow + "] : " + txt + "</br>";
    $('#console').html(displayTxt);
    $('#console').scrollTop(99999);
}
// ------------------------------------------------



//==========================================================
// -------------------------- CLASSES ----------------------
// =============== CLASS Ennemy ============================
function Ennemy(name, type, modifier) {
    this.name = name;
    this.type = type;
    this.modifier = modifier || 'normal';
    this.health = 100;
    this.stamania = 100;
}

function SpawnEnnemy(name, type, modifier) {
    this.name = name;
    this.type = type;
    this.modifier = modifier || 'normal';
}

// ------------------------------------------------


// =============== CLASS Player ============================
function Player(name, lvl) {
    //in-game position
    this.headedTo = 0;
    this.x = 0;
    this.y = 0;

    // wounded, poisonned, OK, etc...
    this.status = [
    ];

    // carac
    this.name = name;
    this.lvl = lvl || 0;
    this.strength = 1;
    this.intell = 1;
    this.stamania = 10;
    this.pv = this.strength * this.stamania;
    this.dodge = this.intell * this.stamania;
}
// ------------------------------------------------


// =============== CLASS Room ============================
function Room(x, y) {
    this.x = x;
    this.y = y;

    // initial room availables directions at generation time :
    // [forward, right, backward, left]
    this.dirs_available = [
        true,
        true,
        true,
        true
    ];
    var nbDir = 4;
    //this.dirs = [true,true,];

    // generating availables directions for the room
    if (x === 0) {
        this.dirs_available[3] = false;
        nbDir--;
    }
    if (x === MAXFLOORSIZE - 1) {
        this.dirs_available[1] = false;
        nbDir--;
    }
    if (y === 0) {
        this.dirs_available[0] = false;
        nbDir--;
    }
    if (y === MAXFLOORSIZE - 1) {
        this.dirs_available[2] = false;
        nbDir--;
    }

    for (i = 0; i < 4; i++) {
        // if this way is free...
        if (this.dirs_available[i] === true) {
            // and there's still at least two posibilities...
            if (nbDir > 1) {
                // do we keep it open ?
                var yes = randomIntFromInterval(0, 2);
                // yes if yes === 1
                if (yes === 0) { //nope
                    this.dirs_available[i] = false;
                    nbDir--;
                }
            }
        }
    }

    // mini map tile =======================
    this.mapTile = null;
    var ways = this.dirs_available;

    if (ways[0] === true && ways[1] === false && ways[2] === true && ways[3] === false) { // straight up
        this.mapTile = MAPTILES.straight_v;
    }
    if (ways[0] === false && ways[1] === true && ways[2] === false && ways[3] === true) { // straight left-right
        this.mapTile = MAPTILES.straight_h;
    }
    if (ways[0] === false && ways[1] === false && ways[2] === true && ways[3] === true) { // angle left-up
        this.mapTile = MAPTILES.left_up;
    }
    if (ways[0] === false && ways[1] === true && ways[2] === true && ways[3] === false) { // angle right-up
        this.mapTile = MAPTILES.right_up;
    }
    if (ways[0] === true && ways[1] === true && ways[2] === false && ways[3] === false) { // angle right-down
        this.mapTile = MAPTILES.right_down;
    }
    if (ways[0] === true && ways[1] === false && ways[2] === false && ways[3] === true) { // angle left-down
        this.mapTile = MAPTILES.left_down;
    }
    if (ways[0] === false && ways[1] === false && ways[2] === true && ways[3] === false) { // bagend-down
        this.mapTile = MAPTILES.bagend_down;
    }
    if (ways[0] === false && ways[1] === true && ways[2] === false && ways[3] === false) { // bagend-right
        this.mapTile = MAPTILES.bagend_right;
    }
    if (ways[0] === true && ways[1] === false && ways[2] === false && ways[3] === false) { // bagend-up
        this.mapTile = MAPTILES.bagend_up;
    }
    if (ways[0] === false && ways[1] === false && ways[2] === false && ways[3] === true) { // bagend-left
        this.mapTile = MAPTILES.bagend_left;
    }
    if (ways[0] === true && ways[1] === true && ways[2] === true && ways[3] === false) { // 3way up left down
        this.mapTile = MAPTILES.threeways_right;
    }
    if (ways[0] === false && ways[1] === true && ways[2] === true && ways[3] === true) { // 3way left right down
        this.mapTile = MAPTILES.threeways_down;
    }
    if (ways[0] === true && ways[1] === false && ways[2] === true && ways[3] === true) { // 3way up left down
        this.mapTile = MAPTILES.threeways_left;
    }
    if (ways[0] === true && ways[1] === true && ways[2] === false && ways[3] === true) { // 3way up right down
        this.mapTile = MAPTILES.threeways_up;
    }
    if (ways[0] === true && ways[1] === true && ways[2] === true && ways[3] === true) { // freeway
        this.mapTile = MAPTILES.freeway;
    }

    // Enemy ==================
    this.enemy = null;

    // loot =====================
    this.loot = null;
}
// ------------------------------------------------
