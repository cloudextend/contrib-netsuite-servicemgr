#!/bin/bash


mkdir -p WSDL_UPGRADE

echo "Created WSDL_UPGRADE folder"

dotnet svcutil https://webservices.netsuite.com/wsdl/v2021_2_0/netsuite.wsdl -n "*,SuiteTalk" --outputDir WSDL_UPGRADE

echo "Copying Reference.cs file to Celigo.SuiteTalk\src\Connected Services\SuiteTalk"

cp WSDL_UPGRADE/Reference.cs Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk

python3 prepare-reference.py --replace ./Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk/Reference.cs

python3 prepare-reference.py --validate ./Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk/replaced-Reference.cs

echo "Replacing Reference.cs"

cp Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk/replaced-Reference.cs Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk/Reference.cs

rm Celigo.SuiteTalk/src/Connected\ Services/SuiteTalk/replaced-Reference.cs

sed -ir  "s/_2018_2/_2021_2/g" Celigo.SuiteTalk/src/SuiteTalkSchemas.cs

sed -ir  "s/2018.2/2021.2/g" Celigo.SuiteTalk/src/SuiteTalk/INetSuiteClient.cs

rm -rf Celigo.SuiteTalk/src/SuiteTalk/Generated

rm -rf WSDL_UPGRADE
