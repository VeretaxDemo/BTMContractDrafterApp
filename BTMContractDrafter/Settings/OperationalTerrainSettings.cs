using BTMContractDrafter.Models;
using System.Collections.Generic;

namespace BTMContractDrafter.Settings;

public class OperationalTerrainSettings
{
    private List<OperationalTerrain> GetDefaultOperationalTerrain()
    {
        return new List<OperationalTerrain>
        {
            new OperationalTerrain
            {
                Id = 1,
                Name = "Arctic",
                Description = "Arctic regions are characterized by proximity to planetary poles, or the furthest extent of geographic warming from the planetary equator (solar mid-point). These regions are often characterized by frigid low temperatures, long seasons, sometimes including hole months without a proper sunrise or sunset.  As a result, arctic regions are often thought of as wastelands, though many worlds have thriving ecosystems even in these cold climates.\n\nWildlife: Despite the harsh conditions, arctic regions support a surprising diversity of wildlife. Animals like polar bears, arctic foxes, muskoxen, reindeer, whales, seals, and various bird species are adapted to the extreme environment. Each worlds animal population will be varied depending on what life was transplanted, and what grew up indigeounsly\n\nChallenges: arctic terrain presents various challenges to human activities due to the cold climate, limited vegetation, and difficult access. However, it is also rich in natural resources such as oil, gas, minerals, and fish.\n\nAurora Borealis: While not a terrain feature, the arctic region is well-known for its spectacular natural light display, the Aurora Borealis or Northern Lights, which can be seen in the night sky in certain months."
            },
            new OperationalTerrain
            {
                Id = 2,
                Name = "Desert",
                Description = "Deserts are characterized by an arid climate with extremely low precipitation. They receive little rainfall, and some deserts may experience droughts that last for years. The lack of water is a defining aspect of desert landscapes.  However, just because there is little rainfall does not mean that water sources are scarce, or that there is no wildlife or vegetation to consider.\n\nExtreme Temperatures: Deserts experience extreme temperature fluctuations between day and night due to the lack of moisture to retain heat. Days can be scorching hot, while nights can be quite cold.\n\nAdapted Flora and Fauna: Desert plants and animals have evolved unique adaptations to survive in the harsh conditions. You may find plants with deep root systems, succulents that store water, and animals that are active during cooler hours or have water-conserving behaviors.\n\nSandstorms and Dust Storms: In sandy deserts, sandstorms can occur, creating powerful gusts of wind that lift and transport sand particles across the landscape. Dust storms may also occur, carrying fine dust and silt over long distances.\n\nSparse Vegetation: The vegetation in deserts is typically sparse and consists of resilient, drought-tolerant plants. Cacti, Joshua trees, acacias, and various shrubs are examples of the flora found in desert regions.\n\nUnique Landforms: Deserts can feature unique landforms, such as canyons, mesas, buttes, and wadis (dry riverbeds). These landforms are often the result of erosion caused by infrequent but intense rainfall events.\n\nStunning Sunsets: Due to the lack of humidity and pollution in the air, deserts often offer breathtaking sunsets with vivid colors that stretch across the horizon."
            },
            new OperationalTerrain
            {
                Id = 3,
                Name = "Lunar",
                Description = "Lunar terrain is often what people think of when they think of moons and other non-manmade satellites of various worlds.  While some moons are indistinguishable from some planetary terain, they are usually characterized by\n\nLow Gravity: Because most moons and asteroids are much smaller than the worlds they orbit, this impacts the amount of fuel necessary to land and disembark by shuttle or dropship, change direction in aerospace flight, and impacts the maximum distance of projectile fire, jump-jet maneuvers, and may also result in increased ground speed for mechs and vehicles.\n\nLack of Atmosphere: Lunar terrain often has little if any atmosphere. This means there is no weather, no air pressure, and no wind erosion. As a result, there is no significant weathering on alunar surface, and features can remain preserved for long periods. It also means that ejection from cockpits without protective suits and supplementary oxygen can lead to sudden decompression or death for the occupant.  Cities on Lunar terrain are often enclosed in large dome like structures or carved into the rocky terrain beneath the surface.\n\nCraters: One of the most prominent features of lunar terrain is its many impact craters. These were formed by collisions with asteroids and meteoroids over billions of years. Some craters are large and well-defined, while others are smaller and more degraded. This can result in an impact on military formation deployments, and in some cases can impact electronic sensors and communicatiosn in areas where background electromagnetic radiation is still prominent from orbital debris, ejection fracture, and other radioactive material that has been uncovered due to these impacts."
            },
            new OperationalTerrain
            {
                Id = 4,
                Name = "Sub-Arctic",
                Description = "Regions that lie just south of arctic regions and experience colder and milder conditions compared to the true arctic regions. Sub-arctic environments are characterized by unique features and conditions that set them apart from other climates.\n\nCold Winters: Sub-arctic regions have cold winters with temperatures often dropping below freezing for extended periods. However, the winters are typically milder than those experienced in the true Arctic due to their more southern location.\n\nShort Summers: Summers in the sub-arctic are short but can still experience relatively warm temperatures during the daytime. However, nights can be chilly even in the summer months.\n\nWildlife: Sub-arctic terrain supports diverse wildlife, including mammals like moose, caribou, wolves, and bears. Many bird species also thrive in these regions during the summer months.\n\nNorthern Lights (Aurora Borealis): While not a terrain feature, sub-arctic regions are known for their occasional displays of the Northern Lights, also called the Aurora Borealis. This mesmerizing natural light show is caused by solar particles interacting with the planetary atmosphere.\n\nChallenges for Human Activities: The sub-arctic climate presents challenges for human activities such as agriculture and construction due to the short growing seasons and cold temperatures. However, the region can be rich in natural resources like minerals, oil, and gas.Cultural Significance: Sub-arctic regions are often home to indigenous communities with unique cultures and traditions closely tied to the land and its resources.\n\nChanging Climate: Worlds experiencing geological warming due to man made or solar impacts will also find impact in the Sub-arctic region. Sub-arctic regions are experiencing the impacts of global temperature increase, which can affect wildlife, permafrost stability, and the overall ecosystem."
            }
        };
    }

    public List<OperationalTerrain> GetOperationalTerrainFromDataSource()
    {
        string settingsFilePath = "OperationalTerrainsSettings.json";
        var dataService = new GeneralSettingsService<OperationalTerrain>(settingsFilePath);

        // Get the default UnitSize objects as a backup
        List<OperationalTerrain> defaultOperationalTerrain = GetDefaultOperationalTerrain();

        // Retrieve data from JSON file or generate it if the file doesn't exist
        List<OperationalTerrain> operationalTerrain = dataService.GetDataFromDataSource(defaultOperationalTerrain);
        return operationalTerrain;
    }

    //private OperationalTerrain FindOperationalTerrain(List<OperationalTerrain> operationalTerrainList, int operationalTerrainId)
    //{
    //    return operationalTerrainList.Find(ot => ot.Id == operationalTerrainId);
    //}
}