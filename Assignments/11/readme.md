<h2> Run Script from folder "opgave" using: </h2>

fsharpi import.fsx && fsharpc -a vectorClass.fs && fsharpc -r vectorClass.dll -a planet.fs && fsharpc -r vectorClass.dll -r planet.dll solSystem.fsx && mono solSystem.exe
