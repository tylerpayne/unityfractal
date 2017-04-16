# unityfractal
Fractal Generator for Unity3D

# Usage
Add [Fractal.cs] and [Generator.cs] to your Unity Project's Assets folder. Create two empty GameObjects, add the Generator script to one and Fractal to the other. In the Fractal component, attach the Generator GameObject to the _Generators_ property.

Under the Fractal component the only property of interest is the _Length_ property. The inital line to be subdivided will be _Length_ long, starting from Fractal's position and extending _Length_ units down the forward (z-axis) direction.

The Generator component contains the main properties to edit. The Vector3 list _Generators_ defines how many subdivisions the fractal should make per iteration, and the locations of those subdivided points. Note that these Vector3's __DO NOT__ correspond to _(x,y,z)_ coordinates. The _x_ component specifies the position of a generated point as a percentage along the line being divided. The _y_ and _z_ components specify the vertical and horizontal displacement of a generated point from the line to be divided. The values of _y_ and _z_ define the position of the point by moving _y_\*_Length_ in the local up direction and _z_\*_Length_ in the local right direction.

The _maxIteration_ value defines how many iterations the Fractal should subdivide. Note the number of GameObjects created will explode very quickly with this value. Keep in mind that the number of GameObjects created will equal (n+1)^m where n=_Generators.Length_ and m=_maxIteration_.

_Material_ specifies what material the LineRenderer will draw with.

_Width_ specifies the LineRenderer draw width.

# Example

![koch_curve]

The above Koch Curve is generated with the following parameters:

![koch_param]

![complex_curve]

More complex geometric forms can be created with very subtle tweaks, the above curve is created with the parameters:

![complex_param]

[Fractal.cs]: https://github.com/tylerpayne/unityfractal/blob/master/Fractal.cs
[Generator.cs]: https://github.com/tylerpayne/unityfractal/blob/master/Generator.cs
[koch_curve]: https://github.com/tylerpayne/unityfractal/blob/master/koch.png "Koch Curve"
[koch_param]: https://github.com/tylerpayne/unityfractal/blob/master/koch_parameters.png "Koch Param"
[complex_curve]: https://github.com/tylerpayne/unityfractal/blob/master/complex.png "Complex Curve"
[complex_param]: https://github.com/tylerpayne/unityfractal/blob/master/complex_parameters.png "Complex Param"
