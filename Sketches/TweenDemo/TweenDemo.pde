float valStart = 0;
float valEnd = 500;

float animLength = 5;
float animPlayheadTime = 0; // measured in seconds
boolean isTweenPlaying = false;

float previousTimestamp = 0;

void setup(){
   size(500, 500);
}

void draw(){
  
  background(128); // 50% grey background
  
  float currentTimestamp = millis()/1000.0;
  float dt = currentTimestamp - previousTimestamp;
  previousTimestamp = currentTimestamp;
    
  if(isTweenPlaying) {
    // move playhead forward in time:
    animPlayheadTime += dt;
    // stop playing at end of tween
    if(animPlayheadTime > animLength) {
      isTweenPlaying = false;
      animPlayheadTime = animLength;
    }
  }
  
  println(animPlayheadTime);
  
  // percent
  float p = animPlayheadTime / animLength; 
  
  // manipulate p
  // p = p * p; // "bends" curve down i.e. speeds up the tween over time
  // p = 1 - (1 - p) * (1 - p); // "bends" curve up i.e. slows the tween over time
  p = p * p * (3 - 2 * p); // smooth step i.e. speeds up AND slows down tween once after another
  
  float x = lerp(valStart, valEnd, p);
  
  ellipse(x, height/2.0, 20, 20);
}

void mousePressed() {
 animPlayheadTime = 0; // restarts animation 
 isTweenPlaying = true;
}
