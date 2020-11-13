namespace rec ScreenTimeQuery

///select columns of table "inquiries"
[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type inquiries_select_column =
    /// column name
    | [<CompiledName "category">] Category
    /// column name
    | [<CompiledName "created_at">] CreatedAt
    /// column name
    | [<CompiledName "file_name">] FileName
    /// column name
    | [<CompiledName "id">] Id
    /// column name
    | [<CompiledName "original">] Original
    /// column name
    | [<CompiledName "text">] Text
    /// column name
    | [<CompiledName "title">] Title
    /// column name
    | [<CompiledName "tsv">] Tsv
    /// column name
    | [<CompiledName "updated_at">] UpdatedAt
    /// column name
    | [<CompiledName "year">] Year

///column ordering options
[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type order_by =
    /// in the ascending order, nulls last
    | [<CompiledName "asc">] Asc
    /// in the ascending order, nulls first
    | [<CompiledName "asc_nulls_first">] AscNullsFirst
    /// in the ascending order, nulls last
    | [<CompiledName "asc_nulls_last">] AscNullsLast
    /// in the descending order, nulls first
    | [<CompiledName "desc">] Desc
    /// in the descending order, nulls first
    | [<CompiledName "desc_nulls_first">] DescNullsFirst
    /// in the descending order, nulls last
    | [<CompiledName "desc_nulls_last">] DescNullsLast

/// input type for inserting array relation for remote table "Home.ScreenTime"
type Home_ScreenTime_arr_rel_insert_input =
    { data: list<Home_ScreenTime_insert_input> }

/// input type for inserting data into table "Home.ScreenTime"
type Home_ScreenTime_insert_input =
    { Begin: Option<System.DateTimeOffset>
      End: Option<System.DateTimeOffset>
      ForegroundTitle: Option<string>
      Host: Option<string>
      IdleSeconds: Option<int>
      User: Option<string>
      id: Option<int> }

/// input type for inserting object relation for remote table "Home.ScreenTime"
type Home_ScreenTime_obj_rel_insert_input = { data: Home_ScreenTime_insert_input }

/// expression to compare columns of type Int. All fields are combined with logical 'AND'.
type Int_comparison_exp =
    { _eq: Option<int>
      _gt: Option<int>
      _gte: Option<int>
      _in: Option<list<int>>
      _is_null: Option<bool>
      _lt: Option<int>
      _lte: Option<int>
      _neq: Option<int>
      _nin: Option<list<int>> }

/// expression to compare columns of type String. All fields are combined with logical 'AND'.
type String_comparison_exp =
    { _eq: Option<string>
      _gt: Option<string>
      _gte: Option<string>
      _ilike: Option<string>
      _in: Option<list<string>>
      _is_null: Option<bool>
      _like: Option<string>
      _lt: Option<string>
      _lte: Option<string>
      _neq: Option<string>
      _nilike: Option<string>
      _nin: Option<list<string>>
      _nlike: Option<string>
      _nsimilar: Option<string>
      _similar: Option<string> }

/// expression to compare columns of type bytea. All fields are combined with logical 'AND'.
type bytea_comparison_exp =
    { _eq: Option<string>
      _gt: Option<string>
      _gte: Option<string>
      _in: Option<list<string>>
      _is_null: Option<bool>
      _lt: Option<string>
      _lte: Option<string>
      _neq: Option<string>
      _nin: Option<list<string>> }

/// Boolean expression to filter rows from the table "inquiries". All fields are combined with a logical 'AND'.
type inquiries_bool_exp =
    { _and: Option<list<Option<inquiries_bool_exp>>>
      _not: Option<inquiries_bool_exp>
      _or: Option<list<Option<inquiries_bool_exp>>>
      category: Option<String_comparison_exp>
      created_at: Option<timestamptz_comparison_exp>
      file_name: Option<String_comparison_exp>
      id: Option<Int_comparison_exp>
      original: Option<bytea_comparison_exp>
      text: Option<String_comparison_exp>
      title: Option<String_comparison_exp>
      tsv: Option<tsvector_comparison_exp>
      updated_at: Option<timestamptz_comparison_exp>
      year: Option<Int_comparison_exp> }

/// ordering options when selecting data from "inquiries"
type inquiries_order_by =
    { category: Option<order_by>
      created_at: Option<order_by>
      file_name: Option<order_by>
      id: Option<order_by>
      original: Option<order_by>
      text: Option<order_by>
      title: Option<order_by>
      tsv: Option<order_by>
      updated_at: Option<order_by>
      year: Option<order_by> }

/// primary key columns input for table: "inquiries"
type inquiries_pk_columns_input = { id: int }

type search_inquiries_args = { search: Option<string> }

/// expression to compare columns of type timestamptz. All fields are combined with logical 'AND'.
type timestamptz_comparison_exp =
    { _eq: Option<System.DateTimeOffset>
      _gt: Option<System.DateTimeOffset>
      _gte: Option<System.DateTimeOffset>
      _in: Option<list<System.DateTimeOffset>>
      _is_null: Option<bool>
      _lt: Option<System.DateTimeOffset>
      _lte: Option<System.DateTimeOffset>
      _neq: Option<System.DateTimeOffset>
      _nin: Option<list<System.DateTimeOffset>> }

/// expression to compare columns of type tsvector. All fields are combined with logical 'AND'.
type tsvector_comparison_exp =
    { _eq: Option<string>
      _gt: Option<string>
      _gte: Option<string>
      _in: Option<list<string>>
      _is_null: Option<bool>
      _lt: Option<string>
      _lte: Option<string>
      _neq: Option<string>
      _nin: Option<list<string>> }

/// The error returned by the GraphQL backend
type ErrorType = { message: string }
