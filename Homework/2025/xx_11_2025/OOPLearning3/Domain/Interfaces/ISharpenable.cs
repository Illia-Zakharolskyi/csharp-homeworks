using System;

namespace OOPLearning3.Domain.Interfaces;

internal interface ISharpenable
{
    int SharpenLevel { get; }
    void Sharpen();
}