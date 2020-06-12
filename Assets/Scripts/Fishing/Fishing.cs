using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public FishDataCollection fish;
    List <FishDataObject> catchable = new List<FishDataObject>();
    string fishDataCollectionAttraction;
    string currentFishAttraction;

    public Dropdown attractantOptions;
    public Dropdown RetrivalMethodOptions;
    public Dropdown CastingRangeOptions;
    public Dropdown TimeOfDayOptions;
    public Dropdown BodyOfWaterTypeOptions;
    public Dropdown toolRequiredOptions;
    public Dropdown enticeMethdodOptions;



    enum currentAttractant
    {  Lure, Living }
    enum currentRetrivalMethdod
    { Instant, Constant, On,Off }
    enum currentCastingRange
    { Close, Far }
    enum currentTimeOfDay
    { Morning, Day, Evening, Night }
    enum currentBodyOfWaterType
    { Morning, Day, Evening, Night }
    enum currentToolRequiredOptions
    { None, Any, Rod, Spear }
    enum currententiceMethdod
    {
        Rhythmic, Random, Predictive
    }
    // Start is called before the first frame update
    void Start()
    {

       // print(catchable[0]);
        DropDownOptions();
    }
    

    // Update is called once per frame
    void Update()
    {
        //  print(attractantOptions.value);
        fishDataCollectionAttraction = fish.FishDataObjects[1].Attractant[0].instanceOfEnum.ToString();
        SetCurrentFishingMethdod();
        print(currentFishAttraction);
        /*
        if (fishy == fishyss)
        {
            print("caught yeah");
            catchable.Add(fish.FishDataObjects[1]);
        }
        print((currentAttractant)attractantOptions.value);

        print((currentAttractant)attractantOptions.value);
        */
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
