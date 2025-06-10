This is a calculator I built to calculate the maximum possible number of rows you could achieve in a Jenga game given a certain number of complete starting rows. This calculation is based on the official Jenga rules as per their website: https://www.jenga.com/about.php as stated below.

"1 -> taking one block on a turn from any level of the tower (except the one below an incomplete top level), and 2 -> placing it on the topmost level in order to complete it."

This includes a visual proofing of writing each set of moves (moving the 2 blocks from the bottom most row of 3) to the console. Bare in mind that all blocks appear to be facing the same way, I assure you this does not matter as each row will always have 3 blocks no matter their orientation. Also, you can achieve the most height by only pulling the outside blocks leaving the centre block. 

The formula for this calculation ends up being "3(n - 1) where n is the number of complete starting rows for n > 1". In a traditional game of Jenga with 18 complete starting rows, the maximum number of rows you can possibly achieve is 51. However, fun fact, the world record for rows achieved in Jenga is only 40 complete stories with two blocks into the 41st, claimed in 1985 by Robert Grebler.

This was built after a discussion over Jenga ensued at one of the local breweries with some mates.

At the time, we were under the impression you could not take from the top 3 most complete rows of the tower, therefore I did a lot of thinking of the maximum number of rows based on this rule. The formula for this is "3n - 7 where n is the number of complete starting rows for n > 3" if you're curious. Don't quote me on this, I was only willing to confirm this works for rows 3 to 11 as I was drawing visual proofs for myself. Anything further than that, I couldn't be bothered drawing anymore.

For my friends Nate, Mitch, Coop, and co, and my partner JB, I know you couldn't care less and are most likely sick of hearing about my thoughts on this, I hope this brings you some peace of mind that I shall not bore you with Jenga math any longer, until I bring up this fun fact at parties.