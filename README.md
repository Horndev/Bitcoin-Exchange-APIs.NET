Bitcoin-Exchange-APIs.NET
=========================

.NET APIs to access commonly used bitcoin exchanges

The objective of this project is to provide an open source .NET (C#) library for trading on popular bitcoin exchanges.

Note that this is a project which is work in progress.  A private API is being translated into this open-source API over time. 

Objectives
=========================

Phase 1 API: (under translation)

- Support for REST polling interface
- Basic Market utilities such as currencies and assets
- Exchanges: Kraken
 
Phase 2 API: (future version)

- Support for websocket interface
- Support for aggregation services (like http://btc-rates.com/#firehose)

TBD (aiming for BTC-e)

Features:
- Event driven architecture for real-time applications
- Interface framework for real-time trading algorithms
- Integrate into applications and services
- [planned] Deployable as windows service as stand-alone process

Limitations
=========================

- This library does not have any trading algorithms.  Trading bots must be built on top of this framework.

License
=========================

This library is released under the GNU LGPL
