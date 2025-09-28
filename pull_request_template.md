## What does this PR do, and why do we need it?
<!-- Explain the problem that this PR aims to solve, and how it solves it. Screenshots should be provided for frontend changes. -->

## What will existing users have to change when pulling these changes?
<!-- Anyone who has forked this repository will have their own gitignored implementation of IWeddingDetails, so making breaking changes to that will require action. So will database migrations.
Database migrations - Please run `dotnet ef migrations script <previous_migration>` to generate the SQL and put that directly into this section, to help the review process and make it easy for people to update.
IWeddingDetails - Please justify why your changes to this interface (or any classes used in this interface) are necessary. -->

## Are you overriding the default behaviour, or have you added it behind a config option?
<!-- If you're overriding the default behaviour, please justify why this is a clear upgrade over the previous behaviour. For changes which are personal preference, you must add a config option (in IWebsiteConfig) and leave the new behaviour disabled by default. -->

## Does any validation logic need adding/updating?
<!-- The IDetailsAndConfigValidator helps users to spot problems with their configuration sooner. Any configuration that could reasonably be deemed "invalid" should be flagged as a warning or an error, with helpful instructions for why this is important and how to fix it. If you're adding new parameters or assumptions, you may need to introduce more validation. -->

## Any interesting design decisions?
<!-- Please specify anything interesting about your implementation, other solutions you considered etc. -->

## Does this close any issues?
<!-- If so, write "Closes #N" for each issue closed, e.g. "Closes #10, Closes #13" -->
