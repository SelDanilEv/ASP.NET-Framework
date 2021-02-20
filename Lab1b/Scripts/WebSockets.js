var ta, ws = null, bstart, bstop;

window.onload = function () {
    if (Modernizr.websockets) {
        WriteMessage('support', 'yes');
        ta = document.getElementById('ta');
        bstart = document.getElementById('bstart');
        bstop = this.document.getElementById('bstop');
        bstart.disabled = false;
        bstop.disabled = true;
    }
}

function WriteMessage(idspan, txt) {
    document.getElementById(idspan).innerHTML = txt;
}  

function exe_start() {
    if (ws == null) {
        ws = new WebSocket("wss://" + location.host + "/websockets.websocket")
        ws.onopen = function () { ws.send('Connection'); }
        ws.onclose = function (s) { console.log('onclose', s); }
        ws.onmessage = function (evt) { ta.innerHTML += '\n' + evt.data; }
        bstart.disabled = true;
        bstop.disabled = false;
    }
}

function exe_stop() {
    ws.close(3001, 'stopapplication');
    ws = null;
    bstart.disabled = false;
    bstop.disabled = true;
}