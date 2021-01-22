void setup() {
 size(500, 500); 
}

void draw() {
 background(128);
 
 float time = millis()/1000.0;
 
 float x = sin(time) * 200 + width/2; // creates the range of motion for the ellipse (-1, 1) * 200 || the width places the circle in the middle of the screen || Horizontal movement
 float y = cos(time) * 200 + height/2; // Vertical Movement
 
 ellipse(width/2, height/2, 400, 400); // Visualization of Circle
 
 ellipse(x, height/2, 50, 50); // Horizontal Ellipse
 ellipse(width/2, y, 50, 50); // Vertical Ellipse
 ellipse(x, y, 50, 50); // Circle Ellipse
}
