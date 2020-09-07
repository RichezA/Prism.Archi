# Scenario
You want to use await/async to run multiple process in parallel.What is the right way to do it.

## Description
Lot of people don't really understand the await/async and use it straightforward.
But, in most cases, they don't use it rhe right way :)

Here are two samples of code used to run 5 async method at the same time and get the most of the parallel run.
* In the method "ThisDoesNotWorkInParallel"
  * Each task is directly awaited, which cause the main thread to stop and wait before running next one.
  * This is asynchronous, because the main thread may continue (i.e : a windows app won't freeze)
* In the method "ThisWorkInParallel"
  * All tasks are initiated without await, and they start directly.
  * When the result is required, the await is used to make the main thread wait for the result.
  
==> If you want to run code in // you have to start the task and, later, wait for the task ! There is no magic :)
The best way to  wait is to use WhenAll (see below).

### await VS WhenAll
When you use await, if there is an exception in on task, the process will stop and hide potential other exception.
With using WhenAll, all exceptions are aggregated.


### Remarks
*The asynchronous method does not create new thread to run the method. The asynchronous methods runs on the current synchronization context and uses the time on the calling thread. It is beneficial when there is a blocking operations like calling a web service, reading a file, reading a website page that blocks current thread.*

More information on http://www.codedigest.com/quick-start/10/learn-asynchronous-programming-async-await-in-c-in-10-minutes

## Program output
Look at the timers :)
```
ThisDoesNotWorkInParallel
===> This code does NOT work in //
00:00:01.8316319 - Call 1 started
00:00:03.4442442 - Call 2 started
00:00:05.0512284 - Call 3 started
00:00:06.7794055 - Call 4 started
00:00:08.2252062 - Call 5 started
00:00:08.2253551 - Call 1 done : 1809
00:00:08.2254910 - Call 2 done : 1595
00:00:08.2255793 - Call 3 done : 1596
00:00:08.2256712 - Call 4 done : 1726
00:00:08.2257630 - Call 5 done : 1436


===> This code does work //
00:00:00.0000180 - Call 1 started
00:00:00.0001710 - Call 2 started
00:00:00.0003135 - Call 3 started
00:00:00.0004127 - Call 4 started
00:00:00.0005086 - Call 5 started
00:00:01.9166442 - Call 1 done : 1910
00:00:01.9167338 - Call 2 done : 1258
00:00:01.9167950 - Call 3 done : 1157
00:00:01.9931847 - Call 4 done : 1990
00:00:01.9936629 - Call 5 done : 1522

===> This code does work // and keep all exceptions (optimal)
00:00:00.0000418 - Call 1 started
00:00:00.0003239 - Call 2 started
00:00:00.0005764 - Call 3 started
00:00:00.0009771 - Call 4 started
00:00:00.0086499 - Call 5 started
00:00:01.8467072 - Call 1 done : 1696
00:00:01.8471219 - Call 2 done : 1251
00:00:01.8482321 - Call 3 done : 1817
00:00:01.8486171 - Call 4 done : 1460
00:00:01.8492891 - Call 5 done : 1827

```
