Shader "Holes/Depth Mask" {
	SubShader{
		// Очередь должа стоять после объектов
		Tags { "Queue" = "Geometry-1" }

		// Не рисовать никаких цветов, только Z-буфер
		ColorMask 0
		ZWrite On

		// Во время прохода ничего не делаем 
		Pass {}
	}
}
