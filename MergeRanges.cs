using System;
using System.Collections.Generic;
using System.Linq;
   
public static class MergeRanges
{
    public static void DoMergeRanges()
    {
        //List<Meeting> mergedMeetings = mergeRanges(new List<Meeting>(){new Meeting(0,1), new Meeting(3,5), new Meeting(4,8), new Meeting(10,12), new Meeting(9,10)});
        //List<Meeting> mergedMeetings = mergeRanges(new List<Meeting>(){new Meeting(1,2), new Meeting(2,3)});
        //List<Meeting> mergedMeetings = mergeRanges(new List<Meeting>(){new Meeting(1,3), new Meeting(2,4)});
        //List<Meeting> mergedMeetings = mergeRanges(new List<Meeting>(){new Meeting(1,5), new Meeting(2,3)});
        //List<Meeting> mergedMeetings = mergeRanges(new List<Meeting>(){new Meeting(1,10), new Meeting(2,6), new Meeting(3,5), new Meeting(7,9)});
        List<Meeting> mergedMeetings = mergeRangesHelper(new List<Meeting>(){new Meeting(0,1), new Meeting(3,5), new Meeting(4,8), new Meeting(10,12), new Meeting(1,2), new Meeting(9,10)});

        // foreach(var m in mergedMeetings)
        // {
        //     Console.WriteLine(m.ToString());
        // }
    }

    private static List<Meeting> mergeRangesHelper(List<Meeting> meetings)
    {
        if(meetings == null || meetings.Count <= 1) return meetings;

        int rangeStart = -1;
        Meeting currentRange =  null;
        Dictionary<int, Meeting> ranges = new Dictionary<int, Meeting>();

        foreach(var m in meetings)
        {
            if(currentRange == null || m.StartTime - 1 > currentRange.EndTime || m.EndTime + 1 < currentRange.StartTime)
            {
                currentRange = m;
                rangeStart = m.StartTime;
                
                ranges.Add(rangeStart, currentRange);                
            }

            if(m.StartTime < currentRange.StartTime && m.EndTime >= m.StartTime)
            {
                currentRange.StartTime = m.StartTime;
            }

            if(m.EndTime > currentRange.EndTime && m.StartTime <= currentRange.EndTime)
            {
                currentRange.EndTime = m.EndTime;
            }

            ranges[rangeStart] = currentRange;
        }

        //return ranges.Select(x=>x.Value).ToList();

        foreach(var m in ranges)
        {
            Console.WriteLine(m.ToString());
        }

        return null;
    }
}

public class Meeting 
{
    public int StartTime {get;set;}
    public int EndTime {get;set;}

    public Meeting(int start, int end)
    {
        this.StartTime = start;
        this.EndTime = end;
    }

    public override string ToString()
    {
        return $"({this.StartTime} {this.EndTime})";
    }
}