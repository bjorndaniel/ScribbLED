from OmegaArduinoDock import neopixel
import time
import math
from bottle import route, run, static_file,template,request

npixel = neopixel.OnionNeopixel(6, 35, 0x08)
status = npixel.setBrightness(32)
count = 0
while count < 35:
  print "Turning of pixel #" + str(count)
  status = npixel.setPixel(count, 0x00, 0x00, 0x00)
  status = npixel.showPixels()
  count = count +1
  time.sleep(0.1)
# npixel.setPixel(0,0xff,0x00,0x00)
# npixel.setPixel(6,0x00,0x00,0xff)
# npixel.setPixel(7,0x00,0xff,0xff)
# npixel.setPixel(34,0x00,0xff,0xff)
# npixel.setPixel(33,0x00,0xff,0xff)
# status = npixel.showPixels()
# while count < 35:
#   print "Pixel #" + str(count)
#   status = npixel.setPixel(count, 0x80, 0x00, 0x00)
#   status = npixel.setPixel(count+1, 0xff, 0xff, 0xff)
#   status = npixel.showPixels()
#   count = count +1
#   time.sleep(0.03)
@route('/hello/<username>')
def hello(username):
    npixel.setPixel(int(username), 0xff,0xff,0xff)
    npixel.showPixels()
    return "Hello {0}.  Welcome to the Omega World!".format(username)
@route('/<filepath:path>')
def server_static(filepath):
    if filepath.find('.') == -1:
      return static_file(filepath + '.html', root='/home/bottle/static/')
    else:
      return static_file(filepath, root='/home/bottle/static/')
run(host='0.0.0.0', port=8080, debug=True)