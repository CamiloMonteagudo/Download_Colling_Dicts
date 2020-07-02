using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DownloadDict
  {
  public partial class Form1 : Form
    {
    public delegate void dgEndDwn( string hrml );

    string LastUrl;

    List<string> MsgsError  = new List<string>();                       // Lista de errores producidos
    string[]     Letters    = new string[0];                            // Urls para cada una de las letras del diccionario
    List<string> WordsRange = new List<string>();                       // Urls para los rangos de palabras
    List<string> Words      = new List<string>();                       // Urls para las palabras

    HashSet<string> LettersDown = new HashSet<string>();                // Letras que ya fueron descarcadas
    HashSet<string> RangesDown  = new HashSet<string>();                // Rango de palabras que ya fueron descargadas
    HashSet<string> WordsDown   = new HashSet<string>();                // Palabras que ya fueron descargadas

    static string[] Dirs = { "espanol-ingles","english-spanish","italiano-ingles","ingles-italiano","frances-ingles","english-french" };
    string Dir;                                                         // Dirección de traducción

    bool Cancel;

    string pathLetters;                                                 // Archivo que guarda los URLs de las letras
    string pathRanges;                                                  // Archivo que guarda los URLs de los rangos de palabras
    string pathWords;                                                   // Archivo que guarda los URLs de las palabras

    string pathLettersDown;                                             // Archivo que guarda los URLs de las letras descargados
    string pathRangesDown;                                              // Archivo que guarda los URLs de los rangos de palabras descargados
    string pathWordsDown;                                               // Archivo que guarda los URLs de las palabras descargadas

    string pathErrors;                                                  // Archivo con los errores durante el proceso

    int[] DwnOk     = { 0,0,0,0 };                                      // Contadores de descargas completadas
    int[] DwnErrors = { 0,0,0,0 };                                      // Contadores de descargas que no se completaron
    int[] FrmErrors = { 0,0,0,0 };                                      // Contadores de páginas con formato incorrecto
    int[] DwnSkips  = { 0,0,0,0 };                                      // Contadores de páginas que ya estaban descargadas

    Stopwatch time = new Stopwatch();
    public Form1()
      {
      InitializeComponent();
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama al cargar el formulario </summary>
    private void Form1_Load( object sender, EventArgs e )
      {
      var BaseDir = Assembly.GetExecutingAssembly().Location;           // Obtiene la localización del ensamblado
      BaseDir = Path.GetDirectoryName( BaseDir );                       // Quita el nombre de la aplicación

      txtWorkDir.Text = BaseDir;

      cbLangs.SelectedIndex = 0;
      Dir = Dirs[0];                                                    // Dirección de traducción por defecto

      IniciaContadores();
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Inicia todos los contadores de actividades realizadas</summary>
    private void IniciaContadores()
      {
      DwnOk[0]     = DwnOk[1]     = DwnOk[2]     = DwnOk[3]     = 0;
      DwnErrors[0] = DwnErrors[1] = DwnErrors[2] = DwnErrors[3] = 0;
      FrmErrors[0] = FrmErrors[1] = FrmErrors[2] = FrmErrors[3] = 0;
      DwnSkips[0]  = DwnSkips[1]  = DwnSkips[2]  = DwnSkips[3]  = 0;

      lbDwnOkLtrs.Text     = lbDwnOkRngs.Text     = lbDwnOkWrds.Text     = "0";
      lbDwnErrorsLtrs.Text = lbDwnErrorsRngs.Text = lbDwnErrorsWrds.Text = "0";
      lbFrmErrorsLtrs.Text = lbFrmErrorsRngs.Text = lbFrmErrorsWrds.Text = "0";
      lbDwnSkipsLtrs.Text  = lbDwnSkipsRngs.Text  = lbDwnSkipsWrds.Text  = "0";

      lbPCLetters.Text = lbPCRanges.Text  = lbPCWords.Text  = "";
      lbNumLetras.Text = lbNumRanges.Text = lbNumWords.Text = "";

      lbDwnRate.Text = "0";

      var sTime = "(" + DateTime.Now.Day + "-" + DateTime.Now.Month  + "-" + DateTime.Now.Year + ") (" + DateTime.Now.Hour + '_' + DateTime.Now.Minute  + '_' + DateTime.Now.Second + ')';

      pathErrors      = GetFilePath( "Errores-" + sTime, ".txt" );

      pathLetters     = GetFilePath( "Listado-de-Letras"  , ".txt" );
      pathRanges      = GetFilePath( "Listado-de-Rangos"  , ".txt" );
      pathWords       = GetFilePath( "Listado-de-Palabras", ".txt" );

      pathLettersDown = GetFilePath( "Descargas-de-Letras"  , ".txt" );    
      pathRangesDown  = GetFilePath( "Descargas-de-Rangos"  , ".txt" );
      pathWordsDown   = GetFilePath( "Descargas-de-Palabras", ".txt" );

      }

    //=================================================================================================================================
    /// <summary> Atiende el boton para buscar las palabras del diccionario</summary>
    private void btnFindWrds_Click( object sender, EventArgs e )
      {
      Cancel = false;

      IniciaContadores();
      ShowWorking();

      time.Reset();
      time.Start();
      GetUrlLetters();
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Pone o quita el modo trabajo </summary>
    private void ShowWorking( bool sw = true )
      {
      if( sw )  boxDatos.Visible = true;

      btnClose.Visible = !sw;
      btnContinue.Visible = !sw;
      btnCancel.Visible = sw;
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene las Url donde se definen los rangos de palabras para cada letra del diccionario </summary>
    private void GetUrlLetters()
      {
      if( File.Exists( pathLetters ) )
        {
        Letters = File.ReadAllLines( pathLetters );

        ++DwnSkips[0];

        lbNumLetras.Text = Letters.Length.ToString();
        ProcesaLetras();
        }
      else
        {
        var Url  = "https://www.collinsdictionary.com/es/vistazo/" + Dir + '/';

        DownLoadPage( new InfoDown( Url, LettersDownloaded) );
        }
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama cuando se termina de descargar la página de letras</summary>
    private void LettersDownloaded( object sender, RunWorkerCompletedEventArgs e )
      {
      var info = e.Result as InfoDown;
      if( info.Error != 0 )
        {
        ++DwnErrors[0];

        boxDatos.Visible = false;
        MessageBox.Show( info.Msg );
        return;
        }

      ++DwnOk[0];

      Letters = ParseLetras( info.Html );
      if( Letters==null )
        {
        ++FrmErrors[0];
        return;
        }

      File.WriteAllLines( pathLetters, Letters );
      lbNumLetras.Text = Letters.Length.ToString();

      ProcesaLetras();
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Analiza el contenido la página de las letras y obtiene las Urls correspondiente a cada letra</summary>
    private string[] ParseLetras( string html )
      {
      try
        {
        int i = 0;
        var tagIni = "<ul class='browse-letters'>";
        var Letras = GetTagInner( html, tagIni, "</ul>", ref i );

        var Urls = new List<string>();

        var ini = html.IndexOf( tagIni ) + tagIni.Length;
        int j = 0;

        for( ; ini + j < i-10; )
          {
          var Letra = GetTagInner( Letras, "li", ref j );
          var Url   = GetAttribute( Letra, "href" );

          Urls.Add( Url );
          }

        return Urls.ToArray();
        }
      catch( Exception exc )
        {
        MessageBox.Show( "ERROR: analizando la página de letras\n\r" + exc.Message );
        return null;
        }
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Procesa todas la URLs obtenidas por cada letra y obtiene las URls de los rangos de palabras </summary>
    private void ProcesaLetras()
      {
      if( File.Exists( pathRanges ) && File.Exists( pathLettersDown ) )
        {
        WordsRange  = File.ReadAllLines( pathRanges ).ToList();
        LettersDown = new HashSet<string>( File.ReadAllLines( pathLettersDown ) );
        }
      else
        {
        WordsRange  = new List<string>();
        LettersDown = new HashSet<string>();
        }

      lbNumRanges.Text = WordsRange.Count.ToString();
      if( Letters.Length > 0 )
        lbPCLetters.Text = ((100.0*LettersDown.Count)/Letters.Length).ToString("0.#") + " %";

      ProcesaNowLetter( 0 );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Procesa la letra actual para obtener los rangos de palabras, cuando termina continua con la otra letra </summary>
    private void ProcesaNowLetter( int idx )
      {
      if( idx<0 || idx>=Letters.Length )
        {
        EndProcesaLetters();
        return;
        }

      var LetraUrl = Letters[ idx ];

      if( LettersDown.Contains( LetraUrl ) )
        SkipDownload(  new InfoDown( LetraUrl, SkipLetter, idx) );
      else
        DownLoadPage(  new InfoDown( LetraUrl, RangesDownloaded, idx) );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Salta una letra que ya fue leida y continua analizando la proxima</summary>
    private void SkipLetter( object sender, RunWorkerCompletedEventArgs e )
      {
      lbDwnSkipsLtrs.Text = (++DwnSkips[1]).ToString();
      var info = e.Result as InfoDown;

      if( Cancel ) EndProcesaLetters( false );
      else         ProcesaNowLetter( ++info.Idx );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama al descargar una pagina de una letra donde se definen los rangos de palabras </summary>
    private void RangesDownloaded( object sender, RunWorkerCompletedEventArgs e )
      {
      var info = e.Result as InfoDown;
      var LetraUrl = Letters[ info.Idx ];

      if( info.Error != 0 )
        {
        var Msg =  "RangesDownloaded|" + LetraUrl + '|' + info.Msg;
        MsgsError.Add( Msg );

        lbDwnErrorsLtrs.Text = (++DwnErrors[1]).ToString();
        }
      else
        {
        lbDwnOkLtrs.Text = (++DwnOk[1]).ToString();

        var Range = ParseWordsRange( LetraUrl, info.Html );

        if( Range != null )
          {
          LettersDown.Add( LetraUrl );
          WordsRange.AddRange( Range );

          lbNumRanges.Text = WordsRange.Count.ToString();
          }
        else
          lbFrmErrorsLtrs.Text = (++FrmErrors[1]).ToString();

        if( Letters.Length > 0 )
          lbPCLetters.Text = ((100.0*(LettersDown.Count+FrmErrors[1]))/Letters.Length).ToString("0.#") + " %";
        }

      UpdateDwnRate();

      if( Cancel ) EndProcesaLetters( false );
      else         ProcesaNowLetter( ++info.Idx );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Actualiza la velocidad a la que se estan descargando las paginas </summary>
    private void UpdateDwnRate()
      {
      var Seg = time.ElapsedMilliseconds/1000.0;
      var Min = Seg/60.0;

      var Num = DwnOk[0] + DwnOk[1] + DwnOk[2] + DwnOk[3] + DwnErrors[0] + DwnErrors[1] + DwnErrors[2] + DwnErrors[3];

      lbDwnRate.Text  = (Seg/Num).ToString("0.#") + " Seg/Pg   |   " + (Num/Min).ToString("0.#") + " Pg/Min   |   " + Min.ToString("0.#") + " Min";
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene Urls para un rango de palabras </summary>
    private List<string> ParseWordsRange( string letraUrl, string html )
      {
      try
        {
        int i = 0;
        var tagIni    = "<ul class=\"columns2 browse-list\">";
        var grpsHtml = GetTagInner( html, tagIni, "</ul>", ref i );

        var Urls = new List<string>();

        var ini = html.IndexOf( tagIni ) + tagIni.Length;
        int j = 0;

        for( ; ini + j < i-10; )
          {
          var grupo = GetTagInner( grpsHtml, "li", ref j );
          var Url   = GetAttribute( grupo, "href" );

          Urls.Add( Url );
          }

        return Urls;
        }
      catch( Exception exc )
        {
        var Msg =  "ParseWordsRange|" + letraUrl + '|' + exc.Message;
        MsgsError.Add( Msg );
        }

      return null;
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama cuando termina el precesamiento de las letras </summary>
    private void EndProcesaLetters( bool nextProc=true )
      {
      File.WriteAllLines( pathRanges, WordsRange.ToArray() );
      File.WriteAllLines( pathLettersDown, LettersDown.ToArray() );

      if( nextProc )
        {
        if( File.Exists( pathWords ) && File.Exists( pathRangesDown ) )                       // Si existen los dos ficheros
          {
          Words = File.ReadAllLines( pathWords ).ToList();                                    // Actualiza la lista de palabras desde el fichero
          RangesDown = new HashSet<string>( File.ReadAllLines( pathRangesDown ) );            // Actualiza los rangos descargados desde el fichero
          }
        else
          {
          Words  = new List<string>();                                                        // Lista de palabra vacia
          RangesDown = new HashSet<string>();                                                 // Rangos descargados ninguno
          }

        lbNumWords.Text = Words.Count.ToString();
        if( WordsRange.Count > 0 )
          lbPCRanges.Text = ((100.0*RangesDown.Count)/WordsRange.Count).ToString("0.#") + " %";

        ProcesaNowRange( 0 );
        }
      else
        {
        ShowWorking( false );

        WriteFileErrors();

        MessageBox.Show( "El usuario cancelo el proceso, mientras se obtenian los rangos de palabras");
        }
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Procesa el rango actual para obtener las palabras, cuando termina continua con proximo rango </summary>
    private void ProcesaNowRange( int idx )
      {
      if( idx<0 || idx>=WordsRange.Count )
        {
        EndProcesaRanges();
        return;
        }

      var rangeUrl = WordsRange[ idx ];

      if( RangesDown.Contains( rangeUrl ) )
        SkipDownload(  new InfoDown( rangeUrl, SkipRange, idx) );
      else
        DownLoadPage(  new InfoDown( rangeUrl, WordsDownloaded, idx) );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama para saltar la descarga de un rango, porque ya estan descargados </summary>
    private void SkipRange( object sender, RunWorkerCompletedEventArgs e )
      {
      lbDwnSkipsRngs.Text = (++DwnSkips[2]).ToString();

      var info = e.Result as InfoDown;

      if( Cancel ) EndProcesaRanges();
      else         ProcesaNowRange( ++info.Idx );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama al terminar de cargar una página con la definición de un rango de palabras </summary>
    private void WordsDownloaded( object sender, RunWorkerCompletedEventArgs e )
      {
      var info = e.Result as InfoDown;
      var rangeUrl = WordsRange[ info.Idx ];

      if( info.Error != 0 )
        {
        var Msg =  "WordsDownloaded|" + rangeUrl + '|' + info.Msg;
        MsgsError.Add( Msg );

        lbDwnErrorsRngs.Text = (++DwnErrors[2]).ToString();
        }
      else
        {
        lbDwnOkRngs.Text = (++DwnOk[2]).ToString();

        var WordsList = ParseUrlWords( rangeUrl, info.Html );

        if( WordsList != null )
          {
          RangesDown.Add( rangeUrl );
          Words.AddRange( WordsList );

          lbNumWords.Text = Words.Count.ToString();
          }
        else
          lbFrmErrorsRngs.Text = (++FrmErrors[2]).ToString();

        if( WordsRange.Count > 0 )
          lbPCRanges.Text = ((100.0*(RangesDown.Count+FrmErrors[2]))/WordsRange.Count).ToString("0.#") + " %";
        }

      UpdateDwnRate();

      if( Cancel ) EndProcesaRanges();
      else         ProcesaNowRange( ++info.Idx );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene las Url de las palabras dentro de un rango </summary>
    private List<string> ParseUrlWords( string wrdUrl, string html )
      {
      try
        {
        int i = 0;
        var tagIni    = "<ul class=\"columns2 browse-list\">";
        var Words = GetTagInner( html, tagIni, "</ul>", ref i );

        var Urls = new List<string>();

        var ini = html.IndexOf( tagIni ) + tagIni.Length;
        int j = 0;

        for( ; ini + j < i-10; )
          {
          var grupo = GetTagInner( Words, "li", ref j );
          var Url   = GetAttribute( grupo, "href" );

          Urls.Add( Url );
          }

        return Urls;
        }
      catch( Exception exc )
        {
        var Msg =  "ParseUrlWords|" + wrdUrl + '|' + exc.Message;
        MsgsError.Add( Msg );
        }

      return null;
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama cuando se terminan de procesar todos los rangos de palabras, y con ello la busqueda de palabras </summary>
    private void EndProcesaRanges()
      {
      File.WriteAllLines( pathWords, Words.ToArray() );                            // Guarda en un fichero la lista de palabras obtenida
      File.WriteAllLines( pathRangesDown, RangesDown.ToArray() );                  // Guarda en un fichero la lista de rangos analizados

      WriteFileErrors();

      ShowWorking( false );

      if( Cancel )
        MessageBox.Show( "El usuario cancelo el proceso, mientras se obtenian las palabras");
      else
        {
        var Msg = "El proceso termino normalmente";
        if( WordsRange.Count <= RangesDown.Count+FrmErrors[2] )
          MessageBox.Show( Msg + " y se obtubieron todas las palabras");
        else
          MessageBox.Show( Msg + ", pero todavia quedan palabras por obtener");
        }
      }

    //=================================================================================================================================
    /// <summary> Descarga la información sobre las palabras</summary>
    private void btnDownWords_Click( object sender, EventArgs e )
      {
      Cancel = false;

      if( File.Exists( pathWords ) )   Words = File.ReadAllLines( pathWords ).ToList(); 
      else
        {
        MessageBox.Show("No existen palabras para descargar, primero se debe ejecutar 'Encontrar Palabras'");
        return;
        }

      if( File.Exists(pathWordsDown) ) WordsDown = new HashSet<string>( File.ReadAllLines( pathWordsDown ) ); 
      else                             WordsDown = new HashSet<string>(); 

      IniciaContadores();
      ShowWorking();

      time.Reset();
      time.Start();

      lbNumWords.Text = Words.Count.ToString();
      if( WordsRange.Count > 0 )
        lbPCRanges.Text = ((100.0*RangesDown.Count)/WordsRange.Count).ToString("0.#") + " %";

      ProcesaNowWord( 0 );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Procesa la palabra actual </summary>
    private void ProcesaNowWord( int idx )
      {
      if( idx<0 || idx>=Words.Count )
        {
        EndProcesaWords();
        return;
        }

      var WordUrl = Words[ idx ];

      if( WordsDown.Contains( WordUrl ) )
        SkipDownload(  new InfoDown( WordUrl, SkipWord, idx) );
      else
        DownLoadPage(  new InfoDown( WordUrl, WordsDataDownloaded, idx) );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama cuando los datos de las palabra actual ya han sido descargados</summary>
    private void SkipWord( object sender, RunWorkerCompletedEventArgs e )
      {
      lbDwnSkipsWrds.Text = (++DwnSkips[3]).ToString();

      var info = e.Result as InfoDown;

      if( Cancel ) EndProcesaWords();
      else         ProcesaNowWord( ++info.Idx );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Se llama cuando termina la descarga de los datos de la palabra actual</summary>
    private void WordsDataDownloaded( object sender, RunWorkerCompletedEventArgs e )
      {
      var info = e.Result as InfoDown;
      var wordUrl = Words[ info.Idx ];

      if( info.Error != 0 )
        {
        var Msg =  "WordsDataDownloaded|" + wordUrl + '|' + info.Msg;
        MsgsError.Add( Msg );

        lbDwnErrorsWrds.Text = (++DwnErrors[3]).ToString();
        }
      else
        {
        try
          {
          var path = GetWordPath( wordUrl );
          File.WriteAllText( path, info.Html );

          WordsDown.Add( wordUrl );
          if( info.Idx%20 == 0 )
            File.WriteAllLines( pathWordsDown, WordsDown.ToArray() );

          lbDwnOkWrds.Text = (++DwnOk[3]).ToString();
          lbPCWords.Text = ((100.0*WordsDown.Count)/Words.Count).ToString("0.#") + " %";
          }
        catch( Exception exc )
          {
          var Msg =  "WordsDataDownloaded|" + wordUrl + '|' + exc;
          MsgsError.Add( Msg );

          lbFrmErrorsWrds.Text = (++FrmErrors[3]).ToString();
          }
        }

      UpdateDwnRate();

      if( Cancel ) EndProcesaWords();
      else         ProcesaNowWord( ++info.Idx );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Termina el proceso de obtención de los datos de las palabras</summary>
    private void EndProcesaWords()
      {
      File.WriteAllLines( pathWordsDown, WordsDown.ToArray() );
      WriteFileErrors();

      ShowWorking( false );

      if( Cancel )
        MessageBox.Show( "El usuario cancelo el proceso, mientras se descargaban datos de las palabras");
      else
        {
        var Msg = "El proceso termino normalmente";
        if( Words.Count <= WordsDown.Count )
          MessageBox.Show( Msg + " y se obtubieron todos los datos de las palabras");
        else
          MessageBox.Show( Msg + ", pero todavia quedan datos por descargar");
        }
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Escribe los errores y los resultados producidos en un fichero</summary>
    private void WriteFileErrors()
      {
      MsgsError.Add( "");
      MsgsError.Add( "          Cantidades = " + lbNumLetras.Text     + " | " + lbNumRanges.Text      + " | " + lbNumWords.Text      );
      MsgsError.Add( "");
      MsgsError.Add( "        Descargas OK = " + lbDwnOkLtrs.Text     + " | " + lbDwnOkRngs.Text      + " | " + lbDwnOkWrds.Text     );
      MsgsError.Add( "  Descargas Fallidas = " + lbDwnErrorsLtrs.Text + " | " + lbDwnErrorsRngs.Text  + " | " + lbDwnErrorsWrds.Text );
      MsgsError.Add( "    Errores de parse = " + lbFrmErrorsLtrs.Text + " | " + lbFrmErrorsRngs.Text  + " | " + lbFrmErrorsWrds.Text );
      MsgsError.Add( "Descargas Anteriores = " + lbDwnSkipsLtrs.Text  + " | " + lbDwnSkipsRngs.Text   + " | " + lbDwnSkipsWrds.Text  );
      MsgsError.Add( "");
      MsgsError.Add( "         Porcentajes = " + lbPCLetters.Text     + " | " + lbPCRanges.Text       + " | " + lbPCWords.Text       );
      MsgsError.Add( "");
      MsgsError.Add( "Velocidad de descargas = " + lbDwnRate.Text ) ;

      File.WriteAllLines( pathErrors, MsgsError.ToArray() );
      MsgsError.Clear();
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene el contenido entre 'tagIni' y 'tagFin'</summary>
    private string GetTagInner( string html, string tagIni, string tagFin, ref int start )
      {
      var ini = html.IndexOf( tagIni, start );
      if( ini <= 0 ) throw new Exception( "No se encontro la marca inicial '" + tagIni + "'" );

      ini += tagIni.Length;

      var fin = html.IndexOf( tagFin, ini );
      if( fin <= 0 ) throw new Exception( "No se encontro la marca final '" + tagFin + "'" );

      start = fin + tagFin.Length;

      return html.Substring( ini, fin-ini );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Analiza el contenido del tag 'tag'</summary>
    private string GetTagInner( string html, string tag, ref int start )
      {
      var tagIni = '<'  + tag + ' ';
      var tagFin = "</" + tag + '>';

      var ini = html.IndexOf( tagIni, start );
      if( ini <= 0 )
        {
        tagIni = '<'  + tag + '>';
        return GetTagInner( html, tagIni, tagFin, ref start );
        }

      if( ini <= 0 ) throw new Exception( "No se encontro la marca inicial '" + tagIni + "'" );

      var endTag = html.IndexOf( '>', ini + tagIni.Length );

      var fin = html.IndexOf( tagFin, endTag );
      if( fin <= 0 ) throw new Exception( "No se encontro la marca final '" + tagFin + "'" );

      start = fin + tagFin.Length;

      return html.Substring( ini, fin-endTag );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene el valor del primer atributo 'Attr' dentro 'html'</summary>
    private string GetAttribute( string html, string Attr )
      {
      var ini = html.IndexOf( Attr );
      if( ini <= 0 ) throw new Exception( "No se encontro el atributo '" + Attr + "'" );

      ini += Attr.Length;
      while( ini<html.Length &&  html[ini]==' ' ) ++ini;

      if( ini>=html.Length || html[ini] != '=' )
        throw new Exception( "No aprece le signo igual en el atributo '" + Attr + "'" );

      ++ini;

      while( ini<html.Length &&  html[ini]==' ' ) ++ini;

      if( ini>=html.Length || (html[ini] != '"' && html[ini] != '\'') )
        throw new Exception( "No aprece le signo la comilla inicial en el atributo '" + Attr + "'" );

      var sep = html[ ini++ ];

      var fin = html.IndexOf( sep, ini );
      if( fin <= 0 ) throw new Exception( "No aprece le signo la comilla final en el atributo '" + Attr + "'" );

      return html.Substring( ini, fin-ini );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene el camino a un fichero de acuerdo al camino dado y la dirección de traducción </summary>
    private string GetFilePath( string Name, string Ext = ".html", string subDir = "" )
      {
      var path = Path.Combine( txtWorkDir.Text, Dir );
      if( !Directory.Exists( path ) )
        Directory.CreateDirectory( path );

      if( !string.IsNullOrEmpty(subDir) )
        {
        path = Path.Combine( path, subDir );
        if( !Directory.Exists( path ) )
          Directory.CreateDirectory( path );
        }

      var fileName = Name + Ext;

      return Path.Combine( path, fileName );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene el camino del fichero de una palabra</summary>
    private string GetWordPath( string Url )
      {
      var Parts = Url.Split('/');
      var nParts = Parts.Length;
      if( nParts < 4 )
        throw new Exception( "La ruta a la palabra parece incorrecta\r\n" + Url );

      var fileName = Parts[ nParts-1 ];

      return GetFilePath( fileName, ".html", "Words" );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Trata de descargar una página web, con la información dada en 'info'</summary>
    private void SkipDownload( InfoDown info )
      {
      var BckWork2 = new BackgroundWorker();

      BckWork2.DoWork +=  (sender, e) =>  { e.Result = info; };

      BckWork2.RunWorkerCompleted += info.NextFunc;

      lbMsgs.Text = "Saltando...\r\n" + info.Url;

      BckWork2.RunWorkerAsync( info );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Trata de descargar una página web, con la información dada en 'info'</summary>
    private void DownLoadPage( InfoDown info )
      {
      var BckWork1 = new BackgroundWorker();

      BckWork1.DoWork +=  ( sender, e ) =>
        {
        using( WebClient client = new WebClient() )
          {
          try
            {
            SetProxy( client );
            SetHeader( client );

            client.Encoding = Encoding.UTF8;
            info.Html = client.DownloadString( new Uri( info.Url ) );
            }
          catch( Exception exc )
            {
            info.Error = 1;
            info.Msg   = exc.Message;
            }
          }

        e.Result = info;
        };

      BckWork1.RunWorkerCompleted += info.NextFunc;

      LastUrl = info.Url;
      lbMsgs.Text = "Descargando...\r\n" + info.Url;

      BckWork1.RunWorkerAsync( info );
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Pone los encabezamientos a la conección para que el servidor interprete la solicitud correctamente </summary>
    private void SetHeader( WebClient client )
      {
      client.Headers.Add( "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:50.0) Gecko/20100101 Firefox/50.0" );
      client.Headers.Add( "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8" );
      client.Headers.Add( "Accept-Language", "es,es-ES;q=0.8,en-US;q=0.5,en;q=0.3" );
      //      client.Headers.Add( "Accept-Encoding", "gzip, deflate, br");
      //      client.Headers.Add( "Cookie", "_ga=GA1.2.746745532.1510510125; _gid=GA1.2.1747155721.1510510125; cookiePolicyAccepted=true; __gads=ID=1bc3e7647f09717e:T=1510510300:S=ALNI_Mbv2yffTTeEup5X2HGjc5PSmfW8cg; XSRF-TOKEN=a5025eee-28a6-47fc-b1b3-d48f5901157a");
      //      client.Headers.Add( "Connection", "keep-alive");
      //      client.Headers.Add( "Upgrade-Insecure-Requests", "1");
      }

    //---------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Si la conección es atraves de un proxy, obtiene los datos y los pone a la coección </summary>
    private void SetProxy( WebClient client )
      {
      if( chkProxy.Checked )
        {
        var Dir = txtAdress.Text;
        var Port = int.Parse( txtPort.Text );

        client.Proxy = new WebProxy( Dir, Port );
        }
      }

    private void btnWorkDir_Click( object sender, EventArgs e )
      {
      SelFolderDlg.Description = "Seleccione el directorio donde se van a poner la información";
      SelFolderDlg.SelectedPath = txtWorkDir.Text;

      if( SelFolderDlg.ShowDialog() == DialogResult.OK )
        txtWorkDir.Text = SelFolderDlg.SelectedPath;
      }

    private void cbLangs_SelectedIndexChanged( object sender, EventArgs e )
      {
      var idx = cbLangs.SelectedIndex;
      if( idx>=0 && idx<Dirs.Length )
        Dir = Dirs[idx];
      }

    private void btnCancel_Click( object sender, EventArgs e )
      {
      lbMsgs.Text = "CANCELANDO ...  espere un momento";
      Cancel = true;
      }

    private void btnContinue_Click( object sender, EventArgs e )
      {
      boxDatos.Visible = false;
      }

    private void btnClose_Click( object sender, EventArgs e )
      {
      Application.Exit();
      }

    }

  internal class InfoDown
    {
    internal RunWorkerCompletedEventHandler NextFunc;

    public InfoDown( string url, RunWorkerCompletedEventHandler CallBack, int idx = 0 )
      {
      Url = url;
      NextFunc = CallBack;
      Idx = idx;
      }

    public int Error { get; internal set; }
    public int Idx   { get; internal set; }

    public string Html { get; internal set; }
    public string Msg { get; internal set; }
    public string Url { get; internal set; }
    }
  }
