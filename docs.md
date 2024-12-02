# Documentation 
## Hardware reservation
Hardware components can be reserved for the duration of an event. The available hardware consists of a turnstile (*deutsch: Drehkreuz*), a scanner (*deutsch: Funkhandscanner*) and a terminal (*deutsch: Mobiles Scan-Terminal*).

To manage and keep track of hardware reservations, there are two endpoints available: 
- POST hardware/reserve - to make a hardware reservation request.
- GET hardware/status/:id - to watch the status of the reservation request.

### POST hardware/reserve
**Description**: Make a hardware reservation request.

**Requirements**: To make a hardware reservation request, the following conditions must be met:

- The request must be made at least 4 weeks before the start of the event.
- There must be enough quantities of the requested hardware available.
- There must be no existing reservation for the event.

**Request**: The following parameters are required and should be sent in the request body as JSON:

Key | Description | Datatype
----------- | ------------ | ------------
EventId          | The id of the event for which the reservation is made.  | Guid
TurnstileCount        | The number of turnstiles to reserve. | int
ScannerCount        | The number of scanners to reserve. | int
TerminalCount   | The number of terminals to reserve. | int

**Response**: The response object is structured as followed:

Key | Description | Datatype
----------- | ------------ | ------------
Id | The reservation id. | Guid

### GET hardware/status/:id
**Description**: Shows the current status of a hardware reservation request for an event. The status includes the information whether the request has been accepted or not.

**Requirements**: A hardware reservation request must have previously been made using the **POST hardware/reserve** endpoint.

**Request**: The following path parameter is required:

Name | Description | Datatype
----------- | ------------ | ------------
id          | The reservation id.  | Guid

**Response**: The response object is structured as followed:

Key | Description | Datatype
----------- | ------------ | ------------
IsRequestAccepted          | Whether the request has been accepted.  | bool
RequestedHardwareComponents | The name and quantity of the requested hardware components. | Dictionary<string, int>