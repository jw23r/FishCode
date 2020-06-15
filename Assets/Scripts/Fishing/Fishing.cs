
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Fishing : MonoBehaviour
{
    public FishDataCollection fish;
    List<FishDataObject> catchable = new List<FishDataObject>();
    string fishDataCollectionAttraction;
    string fishDataCollectionBodyOfWaterType;
    string fishDataCollectionTimeOfDay;
    string fishDataCollectionToolRequiredy;
    string fishDataCollectionEnticeMethod;
    string fishDataCollectionRetrievalMethod;
    string fishDataCollectionCastingRange;









    //curreent fishing methdos
    string currentFishAttraction;
    string currentFishRetrivalMethdod;
    string currentFishCastingRange;
    string currentFishTimeOfDay;
    static public string currentFishBodyOfWaterType;
    string currentFishToolRequired;
    string currentFishEnticeMethdod;



    //dropdown menus
    public Dropdown attractantOptions;
    public Dropdown RetrivalMethodOptions;
    public Dropdown CastingRangeOptions;
    public Dropdown TimeOfDayOptions;
    public Dropdown BodyOfWaterTypeOptions;
    public Dropdown toolRequiredOptions;
    public Dropdown enticeMethdodOptions;


    int fishCaught;

    enum currentAttractant
    { Lure, Living }
    enum currentRetrivalMethdod
    { Instant, Constant, On, Off }
    enum currentCastingRange
    { Close, Far }
    enum currentTimeOfDay
    { Morning, Day, Evening, Night }
    enum currentBodyOfWaterType
    { Ocean, Lake, Pond, Stream }
    enum currentToolRequiredOptions
    { Rod, Spear }
    enum currententiceMethdod
    {
        Rhythmic, Random, Predictive
    }
    // Start is called before the first frame update
    void Start()
    {
        fishDataCollectionBodyOfWaterType = "Ocearwefesn";
        // print(catchable[0]);
        DropDownOptions();

    }


    // Update is called once per frame
    void Update()
    {
        
        //  print(attractantOptions.value);

        SetCurrentFishingMethdod();

        //print(currentFishAttraction);

        //  print((currentAttractant)attractantOptions.value);

        // print((currentAttractant)attractantOptions.value);

        // SetCurrentFishingMethdod();
    }

    public void CastAndFish()
    {


        for (int i = 0; i < fish.FishDataObjects.Count; i++)
        {
            //  print(fish.FishDataObjects.Count);
           // print(i);
            fishDataCollectionAttraction = fish.FishDataObjects[i].Attractant[0].instanceOfEnum.ToString();
            fishDataCollectionBodyOfWaterType = fish.FishDataObjects[i].BodyOfWaterType[0].instanceOfEnum.ToString();
            fishDataCollectionTimeOfDay = fish.FishDataObjects[i].TimeOfDay[0].instanceOfEnum.ToString();
            fishDataCollectionToolRequiredy = fish.FishDataObjects[i].ToolRequired[0].instanceOfEnum.ToString();
            fishDataCollectionEnticeMethod = fish.FishDataObjects[i].EnticeMethod[0].instanceOfEnum.ToString();
            fishDataCollectionRetrievalMethod = fish.FishDataObjects[i].RetrievalMethod[0].instanceOfEnum.ToString();
            fishDataCollectionCastingRange = fish.FishDataObjects[i].CastingRange[0].instanceOfEnum.ToString();
            if (currentFishBodyOfWaterType == "Ocean" || currentFishBodyOfWaterType == "Lake" || currentFishBodyOfWaterType == "Pond" || currentFishBodyOfWaterType == "Stream")
            {
              //  print("1");

                if (fishDataCollectionBodyOfWaterType == currentFishBodyOfWaterType || fishDataCollectionBodyOfWaterType == "None" || fishDataCollectionBodyOfWaterType == "Any")
                {
                   // print("2");

                    if (fishDataCollectionAttraction == currentFishAttraction || fishDataCollectionAttraction == "Any" || fishDataCollectionAttraction == "None")
                    {
                       // print("3");

                        if (fishDataCollectionTimeOfDay == currentFishTimeOfDay || fishDataCollectionTimeOfDay == "Any" || fishDataCollectionTimeOfDay == "None")
                        {
                           // print("4");

                            if (fishDataCollectionToolRequiredy == currentFishToolRequired || fishDataCollectionToolRequiredy == "Any" || fishDataCollectionToolRequiredy == "None")
                            {
                            //    print("5");

                                if (fishDataCollectionEnticeMethod == currentFishEnticeMethdod || fishDataCollectionEnticeMethod == "Any" || fishDataCollectionEnticeMethod == "None")
                                {
                                  //  print("6");

                                    if (fishDataCollectionRetrievalMethod == currentFishRetrivalMethdod || fishDataCollectionRetrievalMethod == "Any" || fishDataCollectionRetrievalMethod == "None")
                                    {
                                      //  print("7");

                                        if (fishDataCollectionCastingRange == currentFishCastingRange || fishDataCollectionCastingRange == "Any" || fishDataCollectionCastingRange == "None")
                                        {
                                        //    print("8");
                                            catchable.Add(fish.FishDataObjects[i]);
                                            //  print(catchable[0].FishNameTextField);
                                            print(i);
                                            if (i >= fish.FishDataObjects.Count - 1)
                                            {
                                                fishCaught = Random.Range(0, i + 1);
                                                print(catchable[fishCaught].FishNameTextField);
                                                catchable.Clear();
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }

        }
    }

    private void SetCurrentFishingMethdod()
    {
        if (currentAttractant.Lure == (currentAttractant)attractantOptions.value)
        {
            currentFishAttraction = currentAttractant.Lure.ToString();
        }
        if (currentAttractant.Living == (currentAttractant)attractantOptions.value)
        {
            currentFishAttraction = currentAttractant.Living.ToString();
        }
        //sets retrival methdod
        if (currentRetrivalMethdod.Constant == (currentRetrivalMethdod)RetrivalMethodOptions.value)
        {


            currentFishRetrivalMethdod = currentRetrivalMethdod.Constant.ToString();
        }
        if (currentRetrivalMethdod.Instant == (currentRetrivalMethdod)RetrivalMethodOptions.value)
        {


            currentFishRetrivalMethdod = currentRetrivalMethdod.Instant.ToString();
        }
        if (currentRetrivalMethdod.Off == (currentRetrivalMethdod)RetrivalMethodOptions.value)
        {


            currentFishRetrivalMethdod = currentRetrivalMethdod.Off.ToString();
        }
        if (currentRetrivalMethdod.On == (currentRetrivalMethdod)RetrivalMethodOptions.value)
        {


            currentFishRetrivalMethdod = currentRetrivalMethdod.On.ToString();
        }
        //sets how far to cast
        if (currentCastingRange.Close == (currentCastingRange)CastingRangeOptions.value)
        {


            currentFishCastingRange = currentCastingRange.Close.ToString();
        }
        if (currentCastingRange.Far == (currentCastingRange)CastingRangeOptions.value)
        {


            currentFishCastingRange = currentCastingRange.Far.ToString();
        }
        /// sets string for time of day
        if (currentTimeOfDay.Day == (currentTimeOfDay)TimeOfDayOptions.value)
        {


            currentFishTimeOfDay = currentTimeOfDay.Day.ToString();
        }
        if (currentTimeOfDay.Evening == (currentTimeOfDay)TimeOfDayOptions.value)
        {


            currentFishTimeOfDay = currentTimeOfDay.Evening.ToString();
        }
        if (currentTimeOfDay.Morning == (currentTimeOfDay)TimeOfDayOptions.value)
        {


            currentFishTimeOfDay = currentTimeOfDay.Morning.ToString();
        }

        if (currentTimeOfDay.Night == (currentTimeOfDay)TimeOfDayOptions.value)
        {


            currentFishTimeOfDay = currentTimeOfDay.Night.ToString();
        }
        //sets body of water type
        if (currentBodyOfWaterType.Ocean == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
        {


            currentFishBodyOfWaterType = currentBodyOfWaterType.Ocean.ToString();
        }
        if (currentBodyOfWaterType.Lake == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
        {


            currentFishBodyOfWaterType = currentBodyOfWaterType.Lake.ToString();
        }
        if (currentBodyOfWaterType.Pond == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
        {


            currentFishBodyOfWaterType = currentBodyOfWaterType.Pond.ToString();
        }
        if (currentBodyOfWaterType.Stream == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
        {


            currentFishBodyOfWaterType = currentBodyOfWaterType.Stream.ToString();
        }
        //sets string for tool
        if (currentToolRequiredOptions.Rod == (currentToolRequiredOptions)toolRequiredOptions.value)
        {


            currentFishToolRequired = currentToolRequiredOptions.Rod.ToString();
        }
        if (currentToolRequiredOptions.Spear == (currentToolRequiredOptions)toolRequiredOptions.value)
        {


            currentFishToolRequired = currentToolRequiredOptions.Spear.ToString();
        }
        // sets string for entice
        if (currententiceMethdod.Predictive == (currententiceMethdod)enticeMethdodOptions.value)
        {


            currentFishEnticeMethdod = currententiceMethdod.Predictive.ToString();
        }


        if (currententiceMethdod.Random == (currententiceMethdod)enticeMethdodOptions.value)
        {


            currentFishEnticeMethdod = currententiceMethdod.Random.ToString();
        }
        if (currententiceMethdod.Rhythmic == (currententiceMethdod)enticeMethdodOptions.value)
        {


            currentFishEnticeMethdod = currententiceMethdod.Rhythmic.ToString();
        }



    }

    void DropDownOptions()
    {
        // sets attraction dropdown
        string[] enumAttractant = Enum.GetNames(typeof(currentAttractant));
        List<string> currentAttractantDDOptions = new List<string>(enumAttractant);
        attractantOptions.AddOptions(currentAttractantDDOptions);
        // sets retrival dropdown

        string[] enumRetrivalMethodOptions = Enum.GetNames(typeof(currentRetrivalMethdod));
        List<string> currentRetrivalMethdodDDOptions = new List<string>(enumRetrivalMethodOptions);
        RetrivalMethodOptions.AddOptions(currentRetrivalMethdodDDOptions);

        // sets casting range methdod
        string[] enumCastingRangeOptions = Enum.GetNames(typeof(currentCastingRange));
        List<string> enumCastingRangeDDOptions = new List<string>(enumCastingRangeOptions);
        CastingRangeOptions.AddOptions(enumCastingRangeDDOptions);

        //sets time of day
        string[] enumCurrentTimeOfDay = Enum.GetNames(typeof(currentTimeOfDay));
        List<string> enumCurrentTimeOfDayDDOptions = new List<string>(enumCurrentTimeOfDay);
        TimeOfDayOptions.AddOptions(enumCurrentTimeOfDayDDOptions);

        //sets type of water
        string[] enumcurrentBodyOfWaterType = Enum.GetNames(typeof(currentBodyOfWaterType));
        List<string> enumcurrentBodyOfWaterTypeDDOptions = new List<string>(enumcurrentBodyOfWaterType);
        BodyOfWaterTypeOptions.AddOptions(enumcurrentBodyOfWaterTypeDDOptions);

        //sets entice required
        string[] enumcurrententiceMethdod = Enum.GetNames(typeof(currententiceMethdod));
        List<string> enumenumcurrententiceMethdodDDOptions = new List<string>(enumcurrententiceMethdod);
        enticeMethdodOptions.AddOptions(enumenumcurrententiceMethdodDDOptions);

        //setsentice methdod
        string[] enumcurrentToolRequiredOptions = Enum.GetNames(typeof(currentToolRequiredOptions));
        List<string> enumcurrentToolRequireddDDOptions = new List<string>(enumcurrentToolRequiredOptions);
        toolRequiredOptions.AddOptions(enumcurrentToolRequireddDDOptions);
    }
}
