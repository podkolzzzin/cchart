<?
	if(!empty($_GET['get']))
	{
		header("Content-type:application/zip: ZIP");
		if($_GET['get']=="CChart0.2AlphaWinXP.Net3.5.zip" || 
			$_GET['get']=="CChart0.1AlphaWin7.Net4.0.zip" ||
			$_GET['get']=="CChart0.1AlphaWin8.Net4.5.zip")
		{
			echo file_get_content($_GET['get']);
			$arr = json_decode("downloads.json", true);
			$arr['total']++;
			switch($_GET['get'])
			{
				case "CChart0.2AlphaWinXP.Net3.5.zip":
					$arr['xp']++;
					break;
				case "CChart0.1AlphaWin7.Net4.0.zip":
					$arr['w7']++;
					break;
				case "CChart0.1AlphaWin8.Net4.5.zip":
					$arr['w8']++;
					break;
			}
			file_put_contents("downloads.json",json_encode($arr));
			exit;
		}
		else
			echo "404not found";
	}
?>

<html>
	<head>
	</head>
	<body>
	
		<a href="cchart.php?get=CChart0.2AlphaWinXP.Net3.5.zip">
			CChart0.2AlphaWinXP.Net3.5.zip
		</a>
		<br />
		<a href="cchart.php?get=CChart0.1AlphaWin7.Net4.0.zip">
			CChart0.1AlphaWin7.Net4.0.zip
		</a>
		<br />
		<a href="cchart.php?get=CChart0.1AlphaWin8.Net4.5.zip">
			CChart0.1AlphaWin8.Net4.5.zip
		</a>
		<br />
	</body>
</html>