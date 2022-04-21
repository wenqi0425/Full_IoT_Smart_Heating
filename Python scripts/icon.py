from sense_hat import SenseHat

sense = SenseHat()
sense.low_light = True

def cloudy():
    t = (0, 0, 0)
    g = (0, 0, 255)

    image = [
    t,t,t,t,t,t,t,t,
    t,t,g,g,g,g,t,t,
    t,g,g,g,g,g,g,t,
    t,t,t,t,t,t,t,t,
    t,t,t,t,t,t,t,t,
    t,t,t,t,t,t,t,t,
    t,t,t,t,t,t,t,t,
    t,t,t,t,t,t,t,t
    ]

    sense.set_pixels(image)

def sun():
    t = (0, 0, 0)
    o = (255, 187, 0)
    y = (255, 200, 1)
    w = (254, 241, 189)

    image = [
    o,t,t,t,t,t,t,o,
    t,t,o,o,w,o,t,t,
    t,o,y,y,y,w,o,t,
    t,o,w,y,y,y,o,t,
    t,o,y,w,y,y,o,t,
    t,o,o,y,y,w,o,t,
    t,t,o,o,o,o,t,t,
    o,t,t,t,t,t,t,o
    ]

    sense.set_pixels(image)

def fog():
    t = (0, 0, 0)
    b = (10, 38, 234)
    g = (0, 0, 255)

    image = [
    t,t,t,t,t,t,t,t,
    t,t,g,g,g,g,t,t,
    t,g,g,g,g,g,g,t,
    t,t,b,b,b,b,t,t,
    t,t,t,t,t,t,t,t,
    t,b,b,b,b,b,b,t,
    t,t,t,t,t,t,t,t,
    t,b,b,b,b,b,b,t
    ]

    sense.set_pixels(image)

def rain():
    t = (0, 0, 0)
    b = (10, 38, 234)
    g = (0, 0, 255)

    image = [
    t,t,t,t,t,t,t,t,
    t,t,g,g,g,g,t,t,
    t,g,g,g,g,g,g,t,
    t,t,t,t,t,t,t,t,
    t,b,t,t,b,t,b,t,
    t,t,b,t,t,t,t,t,
    t,t,t,t,b,t,t,t,
    t,t,b,t,t,t,b,t
    ]

    sense.set_pixels(image)

def sleet():
    t = (0, 0, 0)
    c = (116, 226, 252)
    b = (10, 38, 234)
    g = (0, 0, 255)

    image = [
    t,t,t,t,t,t,t,t,
    t,t,g,g,g,g,t,t,
    t,g,g,g,g,g,g,t,
    t,t,t,t,t,t,t,t,
    t,c,t,c,t,t,b,t,
    t,t,c,t,t,t,t,t,
    t,c,t,c,t,b,t,t,
    t,t,t,t,t,t,t,t
    ]

    sense.set_pixels(image)

def snow():
    t = (0, 0, 0)
    c = (116, 226, 252)
    g = (0, 0, 255)

    image = [
    t,t,t,t,t,t,t,t,
    t,t,g,g,g,g,t,t,
    t,g,g,g,g,g,g,t,
    t,t,t,t,t,t,t,t,
    t,c,t,c,c,t,c,t,
    t,t,c,t,t,c,t,t,
    t,c,t,c,c,t,c,t,
    t,t,t,t,t,t,t,t
    ]

    sense.set_pixels(image)

def snowstorm():
    t = (0, 0, 0)
    c = (116, 226, 252)
    g = (0, 0, 255)
    y = (255, 255, 0)

    image = [
    t,t,t,t,t,t,t,t,
    t,t,g,g,g,g,t,t,
    t,g,g,g,g,g,g,t,
    t,t,y,t,c,t,c,t,
    t,y,y,t,t,c,t,t,
    t,y,t,t,c,t,c,t,
    t,t,t,t,t,t,t,t,
    t,t,t,t,t,t,t,t
    ]

    sense.set_pixels(image)

def storm():
    t = (0, 0, 0)
    b = (10, 38, 234)
    g = (0, 0, 255)
    y = (255, 255, 0)

    image = [
    t,t,t,t,t,t,t,t,
    t,t,g,g,g,g,t,t,
    t,g,g,g,g,g,g,t,
    t,t,y,t,t,t,t,t,
    t,y,y,t,b,t,b,t,
    t,y,t,t,t,t,t,t,
    t,t,t,t,b,t,t,t,
    t,t,t,t,t,t,b,t
    ]

    sense.set_pixels(image)