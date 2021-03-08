<!DOCTYPE html>
<html>
   <head>
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta charset="UTF-8">
      <title>Τρόποι πληρωμής.</title>
      <link href="payStyle.css" rel="stylesheet" type="text/css">
      <style>div { visibility: hidden;}</style>
   </head>
   <body onload="dateTime()">
      <h2 class="hd"> Αγορά βιβλίου. </h2>
         <?php
         if($_SERVER['REQUEST_METHOD'] == 'POST')
         {
            // declare user
            $servername = "localhost";
            $username = "root";
            $password = "iamalphaandomegathebeginningandtheand";
            $dbname = "firstdata";
            $conn = mysqli_connect($servername, $username, $password, $dbname);
            mysqli_set_charset($conn, "utf8");
            // Check connection
            if (!$conn)
            {
                die("Connection failed: " .mysqli_connect_error());
            }
            if(isset($_POST['krathsh']))
            {
               //QUERY SAVE

               $title = $_POST['title'];
               $numbooks = $_POST['numOBooks'];
               $email = $_POST['eMail'];
               $cardNum = $_POST['cardnum'];
               $exdate = $_POST['expDate'];
               $SVC = $_POST['SVC'];
               $nm = $_POST['name'];
               $lnm = $_POST['lastName'];
               if($numbooks !='' || $email !='' || $cardNum !='' || $exdate !='' || $SVC !='' || $nm !='' || $lnm !='')
               {
                  $query = 'INSERT INTO credentials (bookTitle, numOfCopies, email, cardNumber, expDate, SVC, firstName, lastName) VALUES("' . $title . '", ' . $numbooks . ', "' . $email . '", ' . $cardNum . ', "' . $exdate . '" , ' . $SVC . ', "' . $nm . '", "' .$lnm . '")';
                  mysqli_query($conn, $query);
                  echo "<br/><br/><span>Data Inserted successfully...!!</span>";
               }
               else
               {
                  echo "<p>Insertion Failed <br/> Some Fields are Blank....!!</p>";
               }
         }
         else
         {
            //QUERY SEARCH
            $sql = "SELECT bookTitle, numOfCopies, email, cardNumber, expDate, SVC, firstName, lastName FROM credentials WHERE email='".$_POST['search']."'";
            $retval = mysqli_query( $conn, $sql );
            if(!$retval)
            {
               die('Could not get data: ' . mysql_error());
            }
            while($row = mysqli_fetch_assoc($retval))
            {
               echo "Book Title :{$row['bookTitle']}  <br> ".
               "Number of Ordered books : {$row['numOfCopies']} <br> ".
               "Given email : {$row['email']} <br> ".
               "Card Number : {$row['cardNumber']} <br> ".
               "Exparation Date : {$row['expDate']} <br> ".
               "SVS : {$row['SVC']} <br> ".
               "First Name : {$row['firstName']} <br> ".
               "Last Name : {$row['lastName']} <br> ".
               "--------------------------------<br>";
            }
            echo "Fetched data successfully\n";
               mysqli_close($conn);
         }
         }
         ?>
      <p style="text-align: left; color: #29347B; font-style: italic;">
         Στοιχεία παραγγελίας
      </p>
      <form action="<?PHP __FILE__ ?>" method="post">
         Ημερομηνία: <input type="text" id="demo"/>
         <br>
         <label for="b">Επιλογή τίτλων*:</label>
         <select name="title">
            <option id="title" name="title" value="Το Πορτραίτο του Ντόριαν Γκρέυ.">Το Πορτραίτο του Ντόριαν Γκρέυ.</option>
         </select>
         <label for="c">Αριθμός αντιτύπων*:</label>
         <input type="text" size="10" id="numOfBooks" name="numOBooks" onkeypress="return isNumber(event)" /> <br>
         <label for="d">E-mail:</label>
         <input type="text" size="20" id="email" name="eMail" placeholder="sampleEmail@gmail.com"> <br>
         <input type="reset" value="Ακύρωση"/>
         <input type="button" value="Επικύρωση" id="btn1"/>
         <fieldset>
            <legend>Τρόποι πληρωμής.</legend>
            <label for="firstId" name="payment1"> Mastercard </label>
            <input type="radio" name="payment1" value="p1" id="firstId" onclick="myFunction()">
            <label for="secondID" name="payment1">Visa </label>
            <input type="radio" name="payment1" value="p2" id="secondID" onclick="myFunction()">
         </fieldset>
         <div id="DIV">
            Αριθμός κάρτας:
            <input type="int" size="20" onkeypress="return isNumber(event)" id="cardNum" name="cardnum"> <br>
            Ημερομηνία λήξης:
            <input type="text" size="20" placeholder="MM    /   YY"/ id="expDate" name="expDate"> SVC
            <input type="text" size="1" maxlength="3" id="SVC" name="SVC" onkeypress="return isNumber(event)"><br>
            Όνομα κατόχου: <br>
            <input type="text" size="15" placeholder="Όνομα" id="name" name="name" oninput="validateAlpha();">
            <input type="text" size="15" placeholder="Επώνυμο" id="surname" name="lastName" oninput="validateAlpha();"> <br> <br> <br>
            <input type="reset" value="Ακύρωση">
            <input type="submit" name="krathsh" value="Καταχώρηση κράτησης"><br>
            <label for="search">Εισάγετε το e-mail σας για να δείτε τις αγορές σας:</label>
            <input type="text" id="search" name="search" placeholder="sampleEmail@gmail.com">
            <input type="submit" name="submit" value="Αναζήτηση">
         </div>
      </form>
      <!-- validate number -->
      <script>
         function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
               }
            return true;
         }
         // required fields
         function checkRequired(numBooks) {
            if (numBooks == "") {
               alert("Τα πεδία με * είναι υποχρεωτικά.")
               return false;
            }
            return true;
         }
         function ClickMe() {
            var numBooks = document.getElementById('numOfBooks').value;
            if (checkRequired(numBooks)){
               alert("Τα απαραίτητα στοιχεία συμπληρώθηκαν.")
            }
         }
         document.getElementById('btn1').onclick = function () {ClickMe()};
         function dateTime(){
            n = new Date();
            y = n.getFullYear();
            m = n.getMonth() + 1;
            d = n.getDate();
            document.getElementById('demo').placeholder=d + "/" + m + "/" + y;
         }
         function myFunction() {
             var x = document.getElementById('DIV');
             if (x.style.visibility === 'visible') {
                 x.style.visibility = 'hidden';
             } else {
                 x.style.visibility = 'visible';
             }
         }
         function validateAlpha(){
            var textInput = document.getElementById("name").value;
            var txt = document.getElementById("surname").value;
            textInput = textInput.replace(/[^A-Za-z]/g, "");
            txt = txt.replace(/[^A-Za-z]/g, "");
            document.getElementById("name").value = textInput;
            document.getElementById("surname").value = txt;
         }
         function cardCheck(num, exdate, SVC, name, surname){
            if (num == "" || exdate == "" || SVC == "" || name == "" || surname == ""){
               alert("Όλα τα στοιχεία της κάρτας είναι υποχρεωτικά!")
               return false;
            }
            return true;
         }
         function click(){
            var num = document.getElementById("cardNum").value;
            var exdate = document.getElementById("expDate").value;
            var SVC = document.getElementById("SVC").value;
            var name = document.getElementById("name").value;
            var surname = document.getElementById("surname").value;
            if (cardCheck(num, exdate, SVC, name, surname)){
               var bookPrice = 30;
               var bookName = document.getElementById("numOfTitles").value;
               var numBook = document.getElementById("numOfBooks").value;
               var msg = 'Είστε σίγουροι ότι θέλετε να αποστείλετε την παραγγελία; \n';
               msg += 'Όνομα βιβλίου : ' + bookName + '\n';
               msg += 'Αριθμός βιβλίων : ' + numBook + '\n';
               msg += 'Τελική τιμή : ' + (bookPrice*numBook) + '\n';
               if (confirm(msg)){
                  alert("Ευχαριστούμε για την αγορά, τα " + (bookPrice*numBook) + "ευρώ χρεώθηκαν από τον λογαριασμό που επιλέξατε.")
            }
         }
         }
         document.getElementById('btn2').onclick = function () {click()};
      </script>
   </body>
</html>
