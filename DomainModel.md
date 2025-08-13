# Core Requirements

| Classes        | Methods/Properties                                     | Scenario                                | Outputs                           
| -------------- | ------------------------------------------------------ | --------------------------------------- | --------------------------------- 
| Account.cs     | string Name                                            | A user needs a name to identify         | String with user chosen name                         
| Account.cs     | Guid Id                                                | A user needs an id to avoid name overlap| A unique Guid					 
| Account.cs     | string Password                                        | A user needs a password to login        | A user chosen password              				 
| Account.cs     | List<\SavingsAccount\> Savings                         | A user can have multiple saving accounts| savings1, savings2, etc.                    
| Account.cs     | enum Branches                                          | Branches to associate account with      | Personal, Business, Gift                   
| Account.cs     | CreateAccount(Name, Password                           | A user can create an account            | Registered account with name and password                   
| Account.cs     | Dictionary<Name, Password> Account			                | Dictionary to store user accounts       | A keyvalue pair with name and password                
| Savings.cs     | Datetime Date									                        | Each transaction has a recorded date    | A Datetime                
| Savings.cs     | decimal Credit                                         | Tracks adding money                     | A decimal with money
| Savings.cs     | decimal Debit										                      | Tracks withdrawing money                | A decimal with money            
| Savings.cs     | decimal Balance                                        | Tracks total in savings account         | A decimal with hella money            
| Savings.cs     | GenerateStatement()                                    | Prints overview of transactions         | Returns a bank statement as console output         
| Transaction.cs | decimal RequestedAmount                                | A given value to deposit or withdraw    | A decimal with money               
| Transaction.cs | Deposit(RequestedAmount)                               | Add given value to account              | A new deposit transaction         
| Transaction.cs | Withdraw(RequestedAmount)                              | Withdraw given value from account       | A new withdrawal transaction         
| Overdraft.cs   | decimal MaxOverdraft                                   | The max amount allowed to overdraft     | A decimal to dictate the limit         
| Overdraft.cs   | decimal OverdraftAmount                                | The requested amount of overdraft       | A decimal that gives the request amount         
| Overdraft.cs   | RequestOverdraft()										                  | Request the amount of overdraft		      | Sends the request to a manager account
| Requests.cs	   | List<Requests>		                                      | Overdraft requests from different users | A list of requests for the manager to process
| Requests.cs	   | bool Approved		                                      | Approve or deny state for a request     | Y/N (true/false) for the manager to select
| Requests.cs 	 | ReviewRequest(Requests)	                              | Reviewing user requests as a manager    | Sends the processed request back to user
| Messenger.cs	 | string BankStatement		                                | Bank statement rolled up in a string    | A string with the bankstatements
| Messenger.cs	 | string MessageBody		                                  | The message that wil be send over sms   | A string with to be filled with a message
| Messenger.cs	 | int PhoneSender/Reciever	                              | Phone numbers of sender and reciever    | Phone numbers as ints
| Messenger.cs	 | SendMessage()		                                      | Send the message to the user            | The message sent through sms
