# Introduction

This repo contains small .Net client to communicate with online service **yuml.me**. 

This service allows to generate UML diagrams based on provided UML input.

More on the service can be found on its website (http://yuml.me). 

## How to use it

```
IYumlClientService clientService = new YumlClientService();

string[] umlStrings =
{
   "[Customer|-forname:string;-surname:string|doShiz()]<>-orders*>[Order]",
   "[Order] -0..*>[LineItem{bg:red}]",
   "[Order]-[note:Aggregate Root ala DDD{bg:wheat}]"
};

DiagramFile diagramFile = await clientService.BuildDiagram(umlStrings, FileFormat.Svg);

Console.WriteLine(diagramFile.FileName);
Console.WriteLine(diagramFile.ContentType);
Console.WriteLine(diagramFile.Content.Length);
```