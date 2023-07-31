using BTMContractDrafter.Models;
using System.Collections.Generic;
using BTMContractDrafter.Extensions;

namespace BTMContractDrafter.Settings;

public class TerrainTypesSettingsDataSource : ITerrainTypesSettingsDataSource
{
    private List<OperationalTerrain> _operationalTerrain = new List<OperationalTerrain>();

    public TerrainTypesSettingsDataSource(List<OperationalTerrain> operationalTerrain)
    {
        _operationalTerrain = operationalTerrain;
    }
    public List<TerrainType> GetTerrainTypes()
    {
        string settingsFilePath = "TerrainTypesSettingsDataSource.json";
        var dataService = new GeneralSettingsService<TerrainType>(settingsFilePath);

        // Get the default TerrainType objects as a backup
        List<TerrainType> defaultTerrainTypes = GetDefaultTerrainTypes();

        // Retrieve data from JSON file or generate it if the file doesn't exist
        List<TerrainType> terrainTypes = dataService.GetDataFromDataSource(defaultTerrainTypes);
        return terrainTypes;
    }

    private List<TerrainType> GetDefaultTerrainTypes()
    {
        var terrainTypes = new List<TerrainType>
            {
                new TerrainType
                {
                    Id = 1,
                    Name = "PermaFrost",
                    Description = "Much of the terrain is covered with permafrost, which refers to the permanently frozen layer of soil, rock, and sediment. The presence of permafrost greatly impacts vegetation and construction in the region.",
                   OperationalTerrain = _operationalTerrain.FindById(1)
                },
                new TerrainType
                {
                    Id = 2,
                    Name = "Tundra",
                    Description = "The tundra consists of vast, treeless plains covered with low-lying vegetation such as mosses, lichens, grasses, and small shrubs. The tundra is fragile and takes a long time to recover from disturbances.",
                   OperationalTerrain = _operationalTerrain.FindById(1)
                },
                new TerrainType
                {
                    Id = 3,
                    Name = "Glaciers",
                    Description = "The terrain contains numerous glaciers and ice caps, especially in mountainous or hilly areas, and some islands. These icy features contribute to the region's impressive ice formations and are critical for maintaining global climate stability.",
                   OperationalTerrain = _operationalTerrain.FindById(1)
                },
                new TerrainType
                {
                    Id = 4,
                    Name = "IceShelf",
                    Description = "Large shelves of ice covers much of the region. During the colder months, sea ice forms and covers large areas of the ocean and lake surfaces. On some worlds, the extent and thickness of the sea ice have been declining due to rising global temperatures or increased solar activity.",
                   OperationalTerrain = _operationalTerrain.FindById(1)
                },
                new TerrainType
                {
                    Id = 5,
                    Name = "Fjords",
                    Description = "Along the coasts of some terrain regions, you can find deep, narrow fjords formed by glacial erosion. These fjords create stunning and unique landscapes.",
                   OperationalTerrain = _operationalTerrain.FindById(1)
                },
                new TerrainType
                {
                    Id = 6,
                    Name = "Islands",
                    Description = "The terrain is home to numerous islands, some of which are quite large, like compared to Greenland, while others are smaller and more remote. These islands often have rugged coastlines and diverse wildlife.",
                   OperationalTerrain = _operationalTerrain.FindById(1)
                },
                new TerrainType
                {
                    Id = 7,
                    Name = "Dunes",
                    Description = "Some deserts are characterized with very loose soil which has been eroded by heavy rainfall or wind over the millennia. These dunes typically form where water flow or wind lose their impact or in the shadow of more solid objects or obstructions in the ground. Because of this, many deserts have the attribute of sand dunes, large mounds of sand or silica piled up into loose but traversable hills and valleys. They can provide shade in the day, and a heat source after the sun has set. While not all deserts have extensive sand dunes, they are a common and iconic feature, though their location and shape can change quickly when strong storms, seismic activity, or heavy winds occur in a region. This makes navigation tricky, and the particles from the sand storms caused by weather can impact visual as well as electronic targeting and tracking systems making it easy to surprise or elude an opponent.",
                   OperationalTerrain = _operationalTerrain.FindById(2)
                },
                new TerrainType
                {
                    Id = 8,
                    Name = "RockyHills",
                    Description = "Apart from sand dunes, deserts often consist of rocky and gravelly terrains. The exposed rocks and boulders are a result of erosion and weathering caused by the infrequent but intense rainfall. While many rocky regions are able to support Battlemech and other heavy equipment traffic, high speed course corrections can cause even the most seasoned MechWarrior to take an unexpected tumble. Rocky hills also are known for their geo-magnetic features which may impact electronic sensors shortening their detection ranges. Because of this, many outcroppings or caves left from previous development or erosion can become good hiding places for equipment and personnel, not to mention to make good staging grounds for potential ambushes.",
                   OperationalTerrain = _operationalTerrain.FindById(2)
                },
                new TerrainType
                {
                    Id = 9,
                    Name = "Oasis",
                    Description = "Oases are green, vegetated areas in deserts where underground water sources come to the surface, providing life-supporting conditions for plants and animals. Oasis has historically been essential for human settlement and trade routes in desert regions. Because of how highly prized the farmland and water of an Oasis are, many battles have been fought for their possession as access to clean and potable water could be the difference between a successful campaign and death from dehydration.",
                   OperationalTerrain = _operationalTerrain.FindById(2)
                },
                new TerrainType
                {
                    Id = 10,
                    Name = "SaltFlats",
                    Description = "Some deserts have vast salt flats, also known as salt pans, where salt is left behind as water evaporates. These expansive, flat areas can be blindingly white and stretch as far as the eye can see. However, the elements they leave behind can be very valuable mining resources for both chemical, pharmaceutical, industrial, and weapons construction. For this reason, many salt flats will be covered with many mines, both strip, open-pit, dredging, and vertical shaft mining. Because mines often have a unique combination of heavy equipment, storage facilities, and power generation, mines are a high-priority target for bandits seeking to steal precious minerals for an easy payday. For this reason, larger mines often have full-time mechanized security forces, while smaller, more remote mines may only have security foot patrols, or occasional buggy or half-track escorts.",
                   OperationalTerrain = _operationalTerrain.FindById(2)
                },
                new TerrainType
                {
                    Id = 11,
                    Name = "Maria",
                    Description = "The lunar service is covered with large sections of the maria (Latin for 'seas'). The maria are large, dark, flat plains primarily composed of basaltic lava flows",
                   OperationalTerrain = _operationalTerrain.FindById(3)
                },
                new TerrainType
                {
                    Id = 12,
                    Name = "Highlands",
                    Description = "The lunar service is covered by many sections that fit the description of highlands. These are elevated hills or mountains that stand above the surrounding terrain, and are good locations for communication and monitoring equipment. Because the highlands are more rugged, it is a strategic spot for building larger above-ground complexes, and sometimes, serve as the entrance for underground ones. These highlands may also be marked by basins formed from many impact craters",
                   OperationalTerrain = _operationalTerrain.FindById(3)
                },
                new TerrainType
                {
                    Id = 13,
                    Name = "Rilles",
                    Description = "Lunar rilles are long, narrow depressions or channels on the surface. They are thought to be remnants of ancient lava tubes or collapsed lava channels. They may also serve as a good place to sneak convoys and troop formations around above-ground sensor and radar detection. Some rilles may also serve as solid highways to guide to key underground entrances.",
                   OperationalTerrain = _operationalTerrain.FindById(3)
                },
                new TerrainType
                {
                    Id = 14,
                    Name = "Mountains",
                    Description = "The lunar terrain can also have mountain ranges, some of which are quite tall. For comparison, the tallest lunar mountain on Terra's moon is Mons Huygens, also known as the Lunar Apennines, which rises about 4.5 kilometers (2.8 miles) above the surrounding plains. These mountains can create valleys and rugged sometimes impassable terrain that makes anything but BattleMech travel difficult. Mountains also are prime targets for drilling out underground spaces for cities and industry.",
                   OperationalTerrain = _operationalTerrain.FindById(3)
                },
                new TerrainType
                {
                    Id = 15,
                    Name = "Scarps",
                    Description = "A common feature of Lunar terrain is steep cliffs called scarps, which are believed to be the result of tectonic activity. These scarps can be several kilometers in height. Scaling them without jump jets, or jet packs would prove difficult. Many Scarps serve as great locations for mining and mercantile entertainment.",
                   OperationalTerrain = _operationalTerrain.FindById(3)
                },
                new TerrainType
                {
                    Id = 16,
                    Name = "PermaFrost",
                    Description = "In some sub-arctic regions, especially in northern areas, permafrost can be found. Permafrost is a permanently frozen layer of soil, which can have a significant impact on vegetation and construction. Though the permafrost is not as thick as in arctic climes, it can still cause difficulty to construction and agricultural efforts.",
                   OperationalTerrain = _operationalTerrain.FindById(4)
                },
                new TerrainType
                {
                    Id = 17,
                    Name = "BorealForests",
                    Description = "One of the defining features of sub-arctic terrain is the presence of boreal forests, also known as taiga. These are vast expanses of coniferous trees such as spruce, fir, and pine. The boreal forests are well-adapted to the colder climate and play a significant role in a planet's carbon cycle. These areas also are rich in mineral resources, often the home of many deep water lakes, and rivers which may flow to coastal areas.",
                   OperationalTerrain = _operationalTerrain.FindById(4)
                },
                new TerrainType
                {
                    Id = 18,
                    Name = "LakesAndWetLands",
                    Description = "Sub-arctic areas often have numerous lakes, ponds, and wetlands. These water bodies are essential habitats for various wildlife species and migratory birds. They are prized for their natural resources, as well as home to many population centers and some industrial capacity. For this reason, Lakes and Wetlands are often targets for bandit raids seeking to steal food, natural resources, or just terrorizing the local populace for profit. Depending on the world, Lakes and wetlands are also often characterized by occasional flooding or shore rising due to rains or snowmelt from colder climates nearby. This can prove a hazard to some roadways which may follow the direction of bodies of water or be built close to their shorelines.",
                   OperationalTerrain = _operationalTerrain.FindById(4)
                },
                new TerrainType
                {
                    Id = 19,
                    Name = "RollingHills",
                    Description = "Sub-arctic areas often have more rolling hills than jagged mountains due to long cycles of geologic weathering from wind and or rain. This often leads to discoveries of metals and other key elements useful in industrialization and construction. For this reason, the hills in a Rolling Hills area are highly sought after for their natural resources, as well as their tactical and strategic significance for defense.",
                   OperationalTerrain = _operationalTerrain.FindById(4)
                }
                // Add other TerrainType objects here
            };

        return terrainTypes;
    }

}