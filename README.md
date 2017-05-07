# unityfractal
A fractal generator for Unity3D inspired by Benoit Mandelbrot's initiator-generator scheme as described in his [_The Fractal Geometry of Nature_].

# Usage
Move the contents of the Assets folder to the desired locations in your Unity project.

### Basics
The most basic components are the __Fractal__ and __Generator__. The __Generator__ is essentially an abstract data type, but inherits __MonoBehaviour__ so that you can easily organize various __Generator__ in a scene (See the Example scene). A __Generator__ describes how a generic line segment in a fractal will be divided. This is achieved by creating control points along the line with specific diplacements, then iteratively dividing these newly created line segments in the same way (but in their own local orientation) up to _maxIteration_. 

Add control points along the line by adding elements to the __Vector3__ list _generators_. These control points are positioned a percentage - specified by the _x_ parameter [0-1] - along the line (the length of which is specified later in the Fractal component), and displacements (as percentages of the line length) in the local up and right directions - specified by the _y_ and _z_ paramenters respectively.

Now, on a seperate __GameObject__ with a __Fractal__ component attached, specify the _generator_ property to be your __Generator__ object. Specify the _length_ of the initiator line segment and set _renderPath_ to _true_. The initiator line will have beginning vertex at _transform.localPosition_ and terminating vertex at _transform.localPosition + transform.forward*length_.

Upon playing the scene, __Fractal__ will report its approximate fractal dimension, and its vertex count, the positions of which are made available as a __Vector3__ array in the _path_ property. If _renderPath_ is _true_, a __LineRenderer__ will draw the fractal by connecting each of the vertices.

### Beyond
There are a few scripts included that make it easy to draw, view and capture complex, animated fractals. Check out the Example project for more details. These scripts are, in summary:

__FreeFlyCamera__ - Attach to a camera script to fly around the scene. Bind whatever keys you like.

__CameraCapture__ - Attach to a camera and press "K" while playing (or bind your own key) to render its view to images of arbitrary resolution. Can also capture a series of images seperated by _burstInterval_ seconds for creating GIFS, etc. During a single run, filenames will increment. Between runs it will overwrite files that collide with the specified path.

__Tracer__ - Attach to any __GameObject__ and specify the _fractal_ property to trace that fractal's path at the specified _speed_.

__TraceReplicator__ - Create copies of __Tracer__ and optionally _randomize_ their starting position along the fractal.

__Cloner__ - Create instances of a __GameObject__ _source_ by either rotating it around a _pivot_, translating it along the _pivot_ or scaling it by the components of _pivot_.


# Example

![koch_curve]

The above Koch Curve is generated with the following parameters:

![koch_param]

![complex_curve]

More complex geometric forms can be created with very subtle tweaks, the above curve is created with the parameters:

![complex_param]

[_The Fractal Geometry of Nature_]: https://en.wikipedia.org/wiki/The_Fractal_Geometry_of_Nature
[Fractal.cs]: https://github.com/tylerpayne/unityfractal/blob/master/Fractal.cs
[Generator.cs]: https://github.com/tylerpayne/unityfractal/blob/master/Generator.cs
[Graph.cs]:https://github.com/tylerpayne/unityfractal/blob/master/Graph.cs
[koch_curve]: https://github.com/tylerpayne/unityfractal/blob/master/koch.PNG "Koch Curve"
[koch_param]: https://github.com/tylerpayne/unityfractal/blob/master/koch_parameters.PNG "Koch Param"
[complex_curve]: https://github.com/tylerpayne/unityfractal/blob/master/complex.PNG "Complex Curve"
[complex_param]: https://github.com/tylerpayne/unityfractal/blob/master/complex_parameters.PNG "Complex Param"
