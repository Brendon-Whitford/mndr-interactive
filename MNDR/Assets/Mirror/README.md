# Unity URP Planar Reflections
## Dan Brackenbury

A way to implement planar reflections in the Universal Render Pipeline for Unity, created using Shader Graph.
Probably works in HDRP too if you re-target, but that's wholly unnecessary.

The shader and sub-graphs are themselves editable if you would like to tweak how they appear, but it should account for most things by default, and allows for a lot of editing to be done from within the material editor.

Includes sample materials + textures.

More documentation to come; for the time being, the examples cover a variety of uses (i.e. mirrors being pure metallic and unaffected by fresnel, non-metallic surfaces reflecting objects in place of a cubemap).
The reflections are calculated across the Y plane; this means all models / planes you put the reflections on should be FACING TOWARD Y, otherwise your results will not be correct. See the default plane in Unity as an example.

For best results, make sure your default environmental reflection is set to "Custom" -> "No Cubemap" in your lighting options and make sure to disable reflection probes on the mesh you assign this material to.

The script needs a prefab camera and a "player" camera to reference; the prefab camera is what the reflection camera is created from, and the player camera is the reference camera that the script uses to properly reflect the new camera.
In most cases, you can simply drag the main camera from your scene into both slots in the script.

Follows standard material texture convention for Unity (Smoothness Stored in Alpha of Metalness texture). No AO texture support yet but should be trivial to implement.
