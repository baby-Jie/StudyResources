from time import time
import numpy as np
import matplotlib.path as mpltPath

# regular polygon for testing
lenpoly = 1000
polygon = [[np.sin(x)+0.5,np.cos(x)+0.5] for x in np.linspace(0,2*np.pi,lenpoly)[:-1]]

# random points set of points to test 
N = 100000
points = zip(np.random.random(N),np.random.random(N))


# Ray tracing
def ray_tracing_method(x,y,poly):

    n = len(poly)
    inside = False

    p1x,p1y = poly[0]
    for i in range(n+1):
        p2x,p2y = poly[i % n]
        if y > min(p1y,p2y):
            if y <= max(p1y,p2y):
                if x <= max(p1x,p2x):
                    if p1y != p2y:
                        xints = (y-p1y)*(p2x-p1x)/(p2y-p1y)+p1x
                    if p1x == p2x or x <= xints:
                        inside = not inside
        p1x,p1y = p2x,p2y

    return inside

start_time = time()
inside1 = [ray_tracing_method(point[0], point[1], polygon) for point in points]
print("Ray Tracing Elapsed time: " + str(time()-start_time))

# Matplotlib mplPath
# start_time = time()
# path = mpltPath.Path(polygon)
# inside2 = path.contains_points(points)
# print "Matplotlib contains_points Elapsed time: " + str(time()-start_time)