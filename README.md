<p align="center">
  <a href="https://github.com/akesseler/Plexdata.Dialogs/blob/master/LICENSE.md" alt="license">
    <img src="https://img.shields.io/github/license/akesseler/Plexdata.Dialogs.svg" />
  </a>
  <a href="https://github.com/akesseler/Plexdata.Dialogs/releases/latest" alt="latest">
    <img src="https://img.shields.io/github/release/akesseler/Plexdata.Dialogs.svg" />
  </a>
  <a href="https://github.com/akesseler/Plexdata.Dialogs/archive/master.zip" alt="master">
    <img src="https://img.shields.io/github/languages/code-size/akesseler/Plexdata.Dialogs.svg" />
  </a>
</p>


# Plexdata Dialogs

This library represents a collection of dialog windows especially designed to be used in other 
WFP projects.

For the moment, this library supports two dialog windows. The first one is a replacement of the 
standard Windows message box. The second one is a open folder dialog window allowing to easily 
choose a directory.

## Dialog Box

The _Dialog Box_ represents a simple replacement of the standard Windows message box. This dialog 
has been implemented because of the fact that in WPF the standard Windows message box looks pretty 
ugly.

### Examples

This example demonstrates how to show the `DialogBox` in the simplest possible way.

```
DialogBox.Show(this, message);
```

This example demonstrates how to show the `DialogBox` with a symbol and different buttons.

```
DialogBox.Show(this, message, DialogSymbol.Information, DialogButton.OkCancel);
```

This example demonstrates how to show the `DialogBox` with selecting a different default button.

```
DialogBox.Show(this, message, DialogSymbol.Error, DialogButton.YesNoCancel, DialogOption.DefaultButtonNo);
```

Finally note, it is also possible to provide a user-defined caption as well as to apply other options 
like customized button labels.

## Open Folder Dialog

The _Open Folder Dialog_ instead represents a dialog window allowing users to choose a particular 
directory. This dialog has been implemented because of the fact that such a dialog box does not 
exist in WPF.

### Examples

This example demonstrates how to show the `OpenFolderDialog` in the simplest possible way.

```
OpenFolderDialog.Show(this);
```

This example demonstrates how to show the `OpenFolderDialog` with an additional message.

```
OpenFolderDialog.Show(this, message);
```

This example demonstrates how to show the `OpenFolderDialog` with an initial folder.

```
OpenFolderDialog.Show(this, new DirectoryInfo(@"C:\Users"));
```

Finally note, it is also possible to provide a user-defined caption as well as to provide both, 
a message and an initial folder.

## Exception Box

The _Exception Box_ represents a dialog window allowing users to show exceptions with more details.
Main feature of this dialog box is that inner exceptions can be expanded to bring their details into 
view. 

### Examples

This example demonstrates how to show the `ExceptionBox` in the simplest possible way.

```
try
{
    throw new NotSupportedException();
}
catch (Exception exception)
{
    ExceptionBox.Show(this, exception);
}
```

This example demonstrates how to show the `ExceptionBox` with an additional message.

```
try
{
    throw new NotSupportedException();
}
catch (Exception exception)
{
    ExceptionBox.Show(this, exception, "An exception occurred unexpectedly.");
}
```

Finally please note, the caption of the dialog box can be changed as well.

# Library Usage

**First Way**

Download the compiled library from latest release and include and reference it in your project.

**Second Way**

Download all sources and compile them your own way. Thereafter, include the resulting library in 
your projects and reference it.
