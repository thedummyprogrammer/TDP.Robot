if "%1"=="vs" goto caller_vs
	xcopy .\TDP.Robot.Core.Plugins\bin\Debug\*.* /y .\TDP.Robot.JobEditor\bin\Debug\Lib\Core\*.*
	xcopy .\TDP.Robot.Core.Plugins\bin\Debug\*.* /y .\TDP.TestJobEngineService\bin\Debug\Lib\Core\*.*
goto end


:caller_vs
	xcopy %2\TDP.Robot.Core.Plugins\bin\Debug\*.* /y ..\..\..\TDP.Robot.JobEditor\bin\Debug\Lib\Core\*.*
	xcopy %2\TDP.Robot.Core.Plugins\bin\Debug\*.* /y ..\..\..\TDP.TestJobEngineService\bin\Debug\Lib\Core\*.*
:end