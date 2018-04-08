from OmegaArduinoDock import neopixel
import time
import math
from bottle import route, run, static_file,template,request
npixel = neopixel.OnionNeopixel(6, 35, 0x08)
status = npixel.setBrightness(32)

@route('/hello/<username>')
def hello(username):
  return "Hello {0}.  Welcome to the Omega World!".format(username)
@route('/light/<number>')
def light(number):
  npixel.setPixel(int(number), 0xff,0xff,0xff)
  npixel.showPixels()

@route('/lightoff/<number>')
def light(number):
  npixel.setPixel(int(number), 0x00,0x00,0x00)
  npixel.showPixels()

@route('/')
def server_static():
  return static_file('index.html', root='/home/bottle/static/')

@route('/<filepath:path>')
def server_static(filepath):
  return static_file(filepath, root='/home/bottle/static/')

@route('/lightsoff')
def lightsOff():
  count = 0
  while count < 35:
    print "Turning of pixel #" + str(count)
    status = npixel.setPixel(count, 0x00, 0x00, 0x00)
    status = npixel.showPixels()
    count = count +1
    time.sleep(0.05)
@route('/draw', method='POST')
def draw():
  data = request.json
  for l in data:
    led = l['Led']
    colors = l['Color'].split(';')
    npixel.setPixel(int(led), stringToHex(colors[0]), stringToHex(colors[1]), stringToHex(colors[2]))
  npixel.showPixels()
  return "Ok"
#from https://stackoverflow.com/questions/21879454/how-to-convert-a-hex-string-to-hex-number
def stringToHex(hexString):
  hex_int = int(hexString, 16)
  new_int = hex_int + 0x200
  return new_int
lightsOff()
run(host='0.0.0.0', port=8080, debug=True)
  