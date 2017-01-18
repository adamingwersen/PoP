<h2> Run Script </h2>

fsharpc -a vectorClass.fs && fsharpc -r vectorClass.dll -a planet.fs && fsharpc -r planet.dll solSystem.fsx && mono solSystem.exe
