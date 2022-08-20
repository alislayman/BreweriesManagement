# Brewery and wholesale management

## Overview
- A simple application (Web API based) to manage Brewery, wholesale, and client order.
- Target framework for all projects: .Net Framework 4.7.2
- Entity Framework 6 is used.
- Unit Test Project is used containing some unit tests as demo.

## Database schema & predefined data
- check DBScript.sql file.

## API Documentation
- REST architecture has been used.
-  Swashbuckle (version 5.6.0) has been used.
- You can access swagger.ui using: {baseUrl}/swagger/ui/index.
- Check BreweriesManagement.postman_collection.json file for postman collection.

## Nice to have in future
- UI/UX.
- Complete unit tests.
- Add history for wholesaler orders and client orders.
- Add BED (Begin effective date) and EED (End effective date) for retail and wholesale beer price.
- Add Tax abstraction with implementations to apply taxes on beer's price.