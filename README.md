### Installation

You have 3 options for installation:

- Download and Compile the Source
- Grab the Release DLL 
- Install from Nuget

## Nuget

Install-Package BlizzardCSharp

### Important Overwatch API Information

The Overwatch Client API currently comes in two modes. Stats and Information. These APIs are Unofficial, and may not contain up-to-date or accurate information. The purpose of including them is because Blizzard have yet to release any official API. I am currently looking into alternative APIs, and additional APIs to add if need be. 

### API-Endpoints

All API Endpoints are documented in this Wiki. Please be aware that not all information will be returned at once, you must invoke the correct method to pull the information. 

For Example, if you wish to retrieve a Characters Battle Pets from the World of Warcraft API:

This wouldn't work:
```c#
Character character = Client.WorldOfWarcraft.GetCharacterProfile(string realm, string character);
List<Pet> PetList = character.BattlePets.CollectedList;
```

It doesn't work because the basic profile doesn't return any information, and so the BattlePet CollectedList is empty. 

This is how you would make it work:
```c#
Character character = Client.WorldOfWarcraft.GetCharacterProfile(string realm, string character, CharacterFields.pets);
List<Pet> PetList = character.BattlePets.CollectedList;
```

This works because we are telling the API that we want the Pet information, by passing the CharacterFields enum.


### Credits

-  Nick-Strohm because his BattleNET library was instrumental in learning how to parse and use JSON properly within c#. 
- Blizzard for Official APIs
- Ovrstat and Tekrop for providing Unofficial Overwatch APIs
