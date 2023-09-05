# ColorName
## Get a color name from a provided HEX or RGB color

Returns a color name from a list of 1560+ colors. If there is no exact match, it returns the name of a closest color. 

**Usage:**

*From RGB*

    ColorNameProvider.GetColorNameFromRGB(123,45,1);

*From HEX*

Supports long and shorthand version with or without a leading #
    
    ColorNameProvider.GetColorNameFromHex("#ABABAB");
    ColorNameProvider.GetColorNameFromHex("ABABAB");
    ColorNameProvider.GetColorNameFromHex("#FFF");
    ColorNameProvider.GetColorNameFromHex("FFF");


**Ported from https://chir.ag/projects/name-that-color**

[![NuGet](https://img.shields.io/nuget/v/ColorName.svg)](https://www.nuget.org/packages/ColorName) on [NuGet](https://www.nuget.org/packages/ColorName)

