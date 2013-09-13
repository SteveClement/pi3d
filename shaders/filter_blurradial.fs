/////RADIAL BLUR FILTER/////
//www.cloneproduction.net

precision mediump float;
varying vec2 uv;
uniform sampler2D tex0;
uniform sampler2D tex1;
uniform vec3 unif[20];

vec2 BlurXY = vec2 (-0.4, -0.0); //blur center position
float Amount = 0.3; //blur radial amount
float BlurR = 0.1; //blur rotation amount

void main(void){
  gl_FragColor = vec4(0.0, 0.0, 0.0, 1.0);
  vec2 piv = vec2(BlurXY.x+0.5, BlurXY.y-0.5);
  float wd = texture2D(tex1,uv).x;
  vec2 d = (uv - piv); // from centre to this pixel
  // use radial vec = -dy, dx
  d = d * Amount / 5.0 + vec2(-d.y, d.x) * BlurR / 5.0;
  for (float i=0.0; i<1.0; i+=0.0625){
    //attempt to stop 'wrapping'
    vec2 duv = clamp(uv + d * pow(2.0, i), vec2(0.0, -1.0), vec2(1.0, 0.0));
    gl_FragColor += texture2D(tex0, duv) * 0.0625;
  }
  gl_FragColor.a *= unif[5][2];
}
