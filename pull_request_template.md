## What does this PR do, and why do we need it?
<!-- Explain the problem that this PR aims to solve, and how it solves it. Screenshots should be provided for frontend changes. -->

## What will existing users have to change when pulling these changes?
<!-- Please mention if any action is required from users that have customised the Config directory only. This includes adding required parameters to anything in these interfaces, re-ordering parameters, or other
breaking changes. Please also mention database migrations.
  Database migrations - Please run `dotnet ef migrations script <previous_migration>` to generate the SQL and put that directly into this section, to help the review process and make it easy for people to update.
  Config files - Please justify why your changes to this interface (or any classes used in this interface) are necessary.
-->

## Is this change configurable?
<!-- Can users choose whether to use your new behaviour in IWebsiteConfig, or is this forced upon them after updating? Delete as appropriate: -->
Configurable / Not Configurable / No Behaviour Change
<!-- If you've answered "not configurable", please justify why your change is an objective upgrade over the previous version, and why no user would feasibly prefer the old version. -->

## Does any validation logic need adding/updating?
<!-- The IDetailsAndConfigValidator helps users to spot problems with their configuration sooner. Any configuration that could reasonably be deemed "invalid" should be flagged as a warning or an error, with helpful instructions for why this is important and how to fix it. If you're adding new parameters or assumptions, you may need to introduce more validation. -->

## Are the strings configurable?
<!-- Just double check that you are using IStringProvider for your strings, rather than typing them in directly. If you haven't managed to implement this for some string(s), explain why. -->

## Any interesting design decisions?
<!-- Please specify anything interesting about your implementation, other solutions you considered etc. -->

## Does this close any issues?
<!-- If so, write "Closes #N" for each issue closed, e.g. "Closes #10, Closes #13" -->
