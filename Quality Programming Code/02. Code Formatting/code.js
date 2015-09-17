var browserName = navigator.appName, addScroll = false,
userAgentIndex = (navigator.userAgent.indexOf('MSIE 5') > 0) ||
 (navigator.userAgent.indexOf('MSIE 6') > 0);
if (userAgentIndex){
	addScroll = true;
}

var positionX = 0, positionY = 0;

document.onmousemove = mouseMove; 
if (browserName === "Netscape") {
	document.captureEvents(Event.mouseMove)
}

function mouseMove(event, positionX, positionY)  {
	if (browserName === "Netscape") {
		positionX = event.pageX - 5;	
		positionY = event.pageY;
		if (document.layers['ToolTip'].visibility === 'show') {
			popTip(addScroll, positionX, positionY);
		}
	}
	else {
		positionX = event.x - 5;
		positionY = event.y;
		if (document.all['ToolTip'].style.visibility === 'visible') {
			popTip(addScroll, positionX, positionY);
		}
	}
}

function popTip(addScroll, positionX, positionY){
	var currentLayer;
	if (browserName === "Netscape") 	{
		currentLayer = eval('document.layers[\'ToolTip\']');
		var isPositionXOutOfWindow = (positionX + 120) > window.innerWidth;
		if (isPositionXOutOfWindow) {
			positionX = window.innerWidth - 150;		
		}

		currentLayer.left = positionX + 10;
		currentLayer.top = positionY + 15;
		currentLayer.visibility = 'show';	
	}
	else  {
		currentLayer = eval('document.all[\'ToolTip\']');
		if (currentLayer)	{
			positionX = event.x - 5;
			positionY = event.y;
			if (addScroll) {
				positionX = positionX + document.body.scrollLeft;
				positionY = positionY + document.body.scrollTop;			
			}
			
			var isPositionXOutOfBody = (positionX + 120) > document.body.clientWidth;
			if (isPositionXOutOfBody) {
				positionX -= 150;
			}

			currentLayer.style.pixelLeft = positionX + 10;
			currentLayer.style.pixelTop = positionY + 15;
			currentLayer.style.visibility = 'visible';
		}	
	}
}

function hideTip() {
	if (browserName === "Netscape") {
		document.layers['ToolTip'].visibility = 'hide'; 
	}
	else {
		document.all['ToolTip'].style.visibility = 'hidden'; 
	}
}

function hideMenu1() {
	if (browserName === "Netscape") {
		document.layers['menu1'].visibility = 'hide'; 
	}
	else {
		document.all['menu1'].style.visibility = 'hidden'; 
	}
}

function showMenu1() {
	var currentLayer;
	if (browserName === "Netscape") {
		currentLayer = eval('document.layers[\'menu1\']');
	    currentLayer.visibility = 'show';
	} 
	else {
		currentLayer = eval('document.all[\'menu1\']');
		currentLayer.style.visibility = 'visible';   
	}
}

function hideMenu2() {
	if (browserName === "Netscape") {
		document.layers['menu2'].visibility = 'hide'; 
	}
	else {
		document.all['menu2'].style.visibility = 'hidden'; 
	}
} 

function showMenu2(){
	var currentLayer;
	if (browserName === "Netscape")    {
		currentLayer = eval('document.layers[\'menu2\']');
	    currentLayer.visibility = 'show';
	}
	else {
		currentLayer = eval('document.all[\'menu2\']');
		currentLayer.style.visibility = 'visible';   
	}
}