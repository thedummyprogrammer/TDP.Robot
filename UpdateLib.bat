if "%1"=="vs" goto caller_vs
	copy .\TDP.Robot.Core.Plugins\bin\Debug\*.* /y .\TDP.Robot.JobEditor\bin\Debug\Lib\Core
	copy .\TDP.Robot.Core.Plugins\bin\Debug\*.* /y .\TDP.TestJobEngineService\bin\Debug\Lib\Core
	copy .\DocumentFormatPatch\*.* /y .\TDP.TestJobEngineService\bin\Debug\Lib\Core
	copy .\DocumentFormatPatch\*.* /y .\TDP.Robot.UnitTests\bin\Debug
goto end


:caller_vs
	copy ..\..\..\TDP.Robot.Core.Plugins\bin\Debug\*.* /y ..\..\..\TDP.Robot.JobEditor\bin\Debug\Lib\Core
	copy ..\..\..\TDP.Robot.Core.Plugins\bin\Debug\*.* /y ..\..\..\TDP.TestJobEngineService\bin\Debug\Lib\Core
	copy ..\..\..\DocumentFormatPatch\*.* /y ..\..\..\TDP.TestJobEngineService\bin\Debug\Lib\Core
	copy ..\..\..\DocumentFormatPatch\*.* /y ..\..\..\TDP.Robot.UnitTests\bin\Debug
	
:end