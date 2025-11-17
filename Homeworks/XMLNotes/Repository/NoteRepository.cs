using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XMLNotes.Model;

public class NoteRepository
{
    private readonly string _filePath;

    public NoteRepository(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Создание файла с заметками
    /// </summary>
    /// <returns>Создан файл или нет</returns>
    public bool Create()
    {
        if (_filePath == null) return false;
        if (!File.Exists(_filePath))
        {
            new XDocument(new XElement("Notes")).Save(_filePath);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Получение всех заметок
    /// </summary>
    /// <returns>Список заметок</returns>
    public List<Note> GetAll()
    {
        var doc = XDocument.Load(_filePath);

        return doc.Root.Elements("Note")
            .Select(x => new Note
            {
                Id = Guid.Parse((string)x.Attribute("id")),
                Title = (string)x.Element("Title"),
                Text = (string)x.Element("Text"),
                CreatedAt = DateTime.Parse((string)x.Element("CreatedAt"))
            })
            .ToList();
    }

    /// <summary>
    /// Добавление заметки
    /// </summary>
    /// <param name="note">Заметка</param>
    public void Add(Note note)
    {
        var doc = XDocument.Load(_filePath);

        var element = new XElement("Note",
            new XAttribute("id", note.Id),
            new XElement("Title", note.Title),
            new XElement("Text", note.Text),
            new XElement("CreatedAt", note.CreatedAt.ToString("o"))
        );

        doc.Root.Add(element);
        doc.Save(_filePath);
    }

    /// <summary>
    /// Удаление заметки по GUID
    /// </summary>
    /// <param name="id">/Id удаляемой заметки</param>
    public void Delete(Guid id)
    {
        var doc = XDocument.Load(_filePath);

        var note = doc.Root.Elements("Note")
            .FirstOrDefault(x => Guid.Parse((string)x.Attribute("id")) == id);

        if (note != null)
        {
            note.Remove();
            doc.Save(_filePath);
        }
    }

    /// <summary>
    /// Обновление заметки (редактирование)
    /// </summary>
    /// <param name="updated">Обновленная заметка</param>
    public void Update(Note updated)
    {
        var doc = XDocument.Load(_filePath);

        var note = doc.Root.Elements("Note")
            .FirstOrDefault(x => Guid.Parse((string)x.Attribute("id")) == updated.Id);

        if (note != null)
        {
            note.Element("Title").Value = updated.Title;
            note.Element("Text").Value = updated.Text;
            note.Element("CreatedAt").Value = updated.CreatedAt.ToString("o");

            doc.Save(_filePath);
        }
    }
}
