#version 400
	
	layout (location = 0) in vec3 VertexPosition;
	layout (location = 1) in vec3 VertexNormal;
	layout (location = 2) in vec3 VertexColor;
	
	out vec3 LightIntensity;
	
	uniform mat4 NormalMatrix;
	uniform mat4 ProjectionMatrix;
	uniform float Shininess;
	uniform float GlobalAmbient;
	uniform vec3 LightPosition;
	uniform vec3 LightColor;
	uniform mat4 ModelMatrix;
	uniform mat4 ViewMatrix;

	uniform vec3 SpotDirection;
	uniform float spotCutOffAngle;
	uniform float spotExponent;


	void getEyeSpace( out vec3 norm, out vec4 position )
	{
	  norm = normalize(vec3(NormalMatrix * vec4(VertexNormal,0.0)));
	  position = (ViewMatrix * ModelMatrix) * vec4(VertexPosition,1.0);
	}
	
	vec3 phongModel( vec4 position, vec3 norm )
	{
	 


		vec3 s = normalize(vec3((ViewMatrix * vec4(LightPosition,1.0)) - position));
		vec3 v = normalize(-position.xyz);
		vec3 r = reflect( -s, norm );

		vec3 spotLightDir = normalize(vec3(ViewMatrix * vec4(SpotDirection, 0.0)));
		float sDotSpotDir = max(dot(-s, spotLightDir), 0);
		float cosSpotAngle = cos(radians(spotCutOffAngle));
		float spotEffect = 0;
		if (sDotSpotDir >= cosSpotAngle)
			spotEffect = pow(sDotSpotDir, spotExponent);

		vec3 ambient = vec3(GlobalAmbient) * VertexColor;
		float sDotN = max( dot(s,norm), 0.0 );
		vec3 diffuse = LightColor * VertexColor * sDotN * spotEffect;
		vec3 spec = vec3(0.0);
		if (sDotN > 0.0)
			spec = LightColor * VertexColor *
			pow(max(dot(r, v), 0.0), Shininess) * spotEffect;

		return ambient + diffuse + spec;
	}
	
	/*vec3 phongModel( vec4 position, vec3 norm )
	{

		vec3 L = normalize(LightPosition - eyePosition);
		vec3 E = -normalize(eyePosition.xyz);
		vec3 R = reflect(L, norm);
		vec3 H = normalize(L + E);
		
		vec4 diffuse = max(dot(L, N), 0.0) * VertexColor * LightColor;
		
		vec4 ambient = vec3(GlobalAmbient) * VertexColor;
		
		vec4 specular = pow(max(dot(norm, H), 0.0), Shininess) * VertexColor * LightColor; 
	
		return ambient + diffuse + spec;
	
	}*/
		
	void main()
	{
		vec3 eyeNorm;
		vec4 eyePosition;
		// Get the position and normal in eye space
		getEyeSpace(eyeNorm, eyePosition);
		// Evaluate the lighting equation.
		//LightIntensity = GlobalAmbient * VertexColor;
		//LightIntensity = vec3(0.0,1.0,1.0);
		LightIntensity = phongModel(eyePosition, eyeNorm);
		

		gl_Position = ProjectionMatrix * ViewMatrix * ModelMatrix * vec4(VertexPosition, 1.0);
		//gl_Position = (ProjectionMatrix * ViewMatrix * ModelMatrix) * vec4(VertexPosition, 1.0);
	}