using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BalanceFactor
{
    public string factorType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class BalanceModel
{
    public string balanceID;
    public string balanceName;
    public string balanceType;
    public string description;
    public float currentValue;
    public float targetValue;
    public List<BalanceFactor> factors;
}

[Serializable]
public class BalanceData
{
    public BalanceModel[] balances;
}