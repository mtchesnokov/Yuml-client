# Welcome to Yuml client

## Introduction

This repository contains a small .Net client to communicate with the popular online UML diagram service <a href="https://yuml.me">yuml.me</a>. 

This service allows to easily generate relationship diagrams based on provided UML input.

More on this can be found on its website (https://yuml.me). 

The purpose of the client is to hide HTTP details from the calling code, and thus greatly simplify creating UML relationship diagrams programatically. 

## How to use it
Here is some basic example: 

```
IYumlClientService clientService = new YumlClientService();

string[] umlStrings =
{
   "[Customer|->[Order]",
   "[Customer] ->[Address]",
   "[Order]->[Stock]"
};

DiagramFile diagramFile = await clientService.BuildDiagram(umlStrings, FileFormat.Svg);
```

Example result: 

```
{
  "FileName": "12345.svg",
  "ContentType": "image/svg+xml",
  "Content": "{here is binary content of generated svg file}"
}
```

Here is more advanced example with background color, class methods, and text note:

```
string[] umlStrings =
{
   "[Customer|-forname:string;-surname:string|doShiz()]<>-orders*>[Order]",
   "[Order] -0..*>[LineItem{bg:red}]",
   "[Order]-[note:Aggregate Root ala DDD{bg:wheat}]"
};

DiagramFile diagramFile = await clientService.BuildDiagram(umlStrings, FileFormat.Svg);
```