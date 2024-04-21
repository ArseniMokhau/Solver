This C# test solver application is built using WPF and follows the MVVM
architectural pattern. It utilizes an SQL database for management of questions,
and test results within a responsive user interface.
<br />
<br />
<img src="https://github.com/ArseniMokhau/Solver/assets/99400189/e9f34867-7397-44fd-ab1e-855d5f1cc21a.png" data-canonical-src="https://github.com/ArseniMokhau/Solver/assets/99400189/e9f34867-7397-44fd-ab1e-855d5f1cc21a.png" width="800" height="400" />
<br />
<br />
On startup this application accesses the databse and reads all available quizes, then display them in the right column.
The column scales dynamically with the amount of quizes.
<br />
<br />
<img src="https://github.com/ArseniMokhau/Solver/assets/99400189/c228a618-4cb5-4907-a380-b20b0bded1c3.png" data-canonical-src="https://github.com/ArseniMokhau/Solver/assets/99400189/c228a618-4cb5-4907-a380-b20b0bded1c3.png" width="200" height="250" />
<br />
<br />
When the user selects a quiz from the column, the start button becomes enabled.
On click this button will start the timer.
<br />
<br />
<img src="https://github.com/ArseniMokhau/Solver/assets/99400189/e4270dee-331c-4827-921f-e16949e2bd80.png" data-canonical-src="https://github.com/ArseniMokhau/Solver/assets/99400189/e4270dee-331c-4827-921f-e16949e2bd80.png" width="600" height="30" />
<br />
<br />
As timer starts, the first question is displayed and answer option become available.
If the question has less then 4 possible answers, the options are scaled accordingly.
<br />
<br />
<img src="https://github.com/ArseniMokhau/Solver/assets/99400189/717b9ce7-9a67-4555-a0e3-a739aa3b596f.png" data-canonical-src="https://github.com/ArseniMokhau/Solver/assets/99400189/717b9ce7-9a67-4555-a0e3-a739aa3b596f.png" width="600" height="180" />
<br />
<br />
After the quiz is finished or interrupted via the stop button, the result is displayed along with the time taken.
